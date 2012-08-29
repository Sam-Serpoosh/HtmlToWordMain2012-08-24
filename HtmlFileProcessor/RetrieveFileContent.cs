using System;
using System.IO;

namespace HtmlFileProcessor
{
	public class RetrieveFileContent
	{
		private string _filePath;

		public RetrieveFileContent(string filePath)
		{
			_filePath = filePath;
		}

		public string FileContent()
		{
			StreamReader reader = null;
			try
			{
				reader = new StreamReader(_filePath);
				return reader.ReadToEnd();
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}
			
		}
	}
}
