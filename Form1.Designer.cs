namespace AsyncAwaitTest
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.StartProcess = new System.Windows.Forms.Button();
			this.CancelProcess = new System.Windows.Forms.Button();
			this.DisplayMessage = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(12, 22);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(260, 23);
			this.ProgressBar.TabIndex = 0;
			// 
			// StartProcess
			// 
			this.StartProcess.Location = new System.Drawing.Point(116, 96);
			this.StartProcess.Name = "StartProcess";
			this.StartProcess.Size = new System.Drawing.Size(75, 23);
			this.StartProcess.TabIndex = 1;
			this.StartProcess.Text = "処理開始";
			this.StartProcess.UseVisualStyleBackColor = true;
			this.StartProcess.Click += new System.EventHandler(this.StartProcess_Click);
			// 
			// CancelProcess
			// 
			this.CancelProcess.Location = new System.Drawing.Point(197, 96);
			this.CancelProcess.Name = "CancelProcess";
			this.CancelProcess.Size = new System.Drawing.Size(75, 23);
			this.CancelProcess.TabIndex = 2;
			this.CancelProcess.Text = "処理中止";
			this.CancelProcess.UseVisualStyleBackColor = true;
			this.CancelProcess.Click += new System.EventHandler(this.CancelProcess_Click);
			// 
			// DisplayMessage
			// 
			this.DisplayMessage.Location = new System.Drawing.Point(13, 52);
			this.DisplayMessage.Name = "DisplayMessage";
			this.DisplayMessage.Size = new System.Drawing.Size(259, 23);
			this.DisplayMessage.TabIndex = 3;
			this.DisplayMessage.Text = "hoge";
			this.DisplayMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 135);
			this.Controls.Add(this.DisplayMessage);
			this.Controls.Add(this.CancelProcess);
			this.Controls.Add(this.StartProcess);
			this.Controls.Add(this.ProgressBar);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar ProgressBar;
		private System.Windows.Forms.Button StartProcess;
		private System.Windows.Forms.Button CancelProcess;
		private System.Windows.Forms.Label DisplayMessage;

	}
}

