using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AsyncAwaitTest
{
	//Taskの参考サイト
	//[URL]https://tocsworld.wordpress.com/2014/07/16/c-task%E3%81%AE%E3%82%AD%E3%82%BD

	//非同期処理の種類について
	//[URL]http://csharp.keicode.com/basic/async-intro.php

	//C#の非同期処理を網羅的に
	//[URL]http://blog.xin9le.net/entry/2012/07/27/091353

	public partial class Form1 : Form
	{
		private const int MAXCOUNT = 1000;

		private const int SLEEPTIME = 5;

		public Form1()
		{
			InitializeComponent();

			ProgressBar.Maximum = MAXCOUNT;
		}

		CancellationTokenSource cts;
		TaskScheduler uiTaskScheduler;

		/// <summary>
		/// 処理開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StartProcess_Click(object sender, EventArgs e)
		{
			StartProcess.Enabled = false;

			//キャンセル時に必要
			cts = new CancellationTokenSource();

			//現在のスレッドのコンテキストを取得する(UIを生成したスレッド)
			//生成されたコントロールは生成したスレッド上でしか操作出来ないためそれに利用する
			uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

			//タスクを作成して開始
			Task task = Task.Factory.StartNew(() => TargetTask(), cts.Token);

			bool CancelFLG = false;

			//キャンセル後の処理
			cts.Token.Register(() => CancelTask(out CancelFLG));

			//タスク完了後の処理
			task.ContinueWith(_ => 
			{
				DisplayMessage.Text = CancelFLG == true ? "タスクを中止しました" : "タスクが完了しました";
				StartProcess.Enabled = true;
				if(!CancelFLG) this.Close();
			}, uiTaskScheduler);
			
		}		

		/// <summary>
		/// 実行するタスク
		/// </summary>
		private void TargetTask()
		{
			for (int i = 1; i < MAXCOUNT; i++)
			{
				//UIの生成されたスレッドでタスクを実行する
				Task ProgressbarUpdateTask = new Task(() => 
				{
					ProgressBar.Value = ProgressBar.Value + 1;
					DisplayMessage.Text = i + "/" + MAXCOUNT;	
				});
				//開始
				ProgressbarUpdateTask.Start(uiTaskScheduler);

				//主動となる重い処理がキャンセルされた場合は処理を中止する
				if (cts.IsCancellationRequested)
				{
					return;
				}

				//実行する処理
				Thread.Sleep(SLEEPTIME);
			}
		}

		/// <summary>
		/// キャンセル時に実行するタスク
		/// </summary>
		private void CancelTask(out bool CancelFLG)
		{
			ProgressBar.Value = ProgressBar.Minimum;
			DisplayMessage.Text = "処理をキャンセルしました";
			CancelFLG = true;
		}


		/// <summary>
		/// 処理中止
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelProcess_Click(object sender, EventArgs e)
		{
			cts.Cancel();
		}
	}
}
