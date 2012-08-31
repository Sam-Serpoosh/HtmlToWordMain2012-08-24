using System;
using System.Windows.Forms;
using HtmlToWord;

namespace HtmlToWordUI
{
	public partial class FrmMain : Form
	{
		private string _htmlDocFilePath;

		public FrmMain()
		{
			InitializeComponent();
		}

		private void BtnBrowseClick(object sender, EventArgs e)
		{
			var dialogResult = htmlDocFileDialog.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				_htmlDocFilePath = htmlDocFileDialog.FileName;
				TxtFilePath.Text = _htmlDocFilePath;
			}
		}

		private void BtnGenerateWordClick(object sender, EventArgs e)
		{
			new HtmlToWordGenerator(_htmlDocFilePath).
				GenerateTheWordDocumentForHtmlDoc();

			MessageBox.Show("Document Generated!");
		}

		private static void FrmMainFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
