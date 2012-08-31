namespace HtmlToWordUI
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.htmlDocFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.BtnBrowse = new System.Windows.Forms.Button();
			this.TxtFilePath = new System.Windows.Forms.TextBox();
			this.BtnGenerateWord = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// htmlDocFileDialog
			// 
			this.htmlDocFileDialog.FileName = "htmlDocFileDialog";
			// 
			// BtnBrowse
			// 
			this.BtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnBrowse.Location = new System.Drawing.Point(280, 32);
			this.BtnBrowse.Name = "BtnBrowse";
			this.BtnBrowse.Size = new System.Drawing.Size(75, 23);
			this.BtnBrowse.TabIndex = 0;
			this.BtnBrowse.Text = "Browse";
			this.BtnBrowse.UseVisualStyleBackColor = true;
			this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
			// 
			// TxtFilePath
			// 
			this.TxtFilePath.Location = new System.Drawing.Point(12, 35);
			this.TxtFilePath.Name = "TxtFilePath";
			this.TxtFilePath.Size = new System.Drawing.Size(251, 20);
			this.TxtFilePath.TabIndex = 1;
			// 
			// BtnGenerateWord
			// 
			this.BtnGenerateWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnGenerateWord.Location = new System.Drawing.Point(247, 73);
			this.BtnGenerateWord.Name = "BtnGenerateWord";
			this.BtnGenerateWord.Size = new System.Drawing.Size(108, 23);
			this.BtnGenerateWord.TabIndex = 2;
			this.BtnGenerateWord.Text = "Generate Word";
			this.BtnGenerateWord.UseVisualStyleBackColor = true;
			this.BtnGenerateWord.Click += new System.EventHandler(this.BtnGenerateWordClick);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ClientSize = new System.Drawing.Size(367, 108);
			this.Controls.Add(this.BtnGenerateWord);
			this.Controls.Add(this.TxtFilePath);
			this.Controls.Add(this.BtnBrowse);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Word Generator";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmMainFormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog htmlDocFileDialog;
		private System.Windows.Forms.Button BtnBrowse;
		private System.Windows.Forms.TextBox TxtFilePath;
		private System.Windows.Forms.Button BtnGenerateWord;
	}
}

