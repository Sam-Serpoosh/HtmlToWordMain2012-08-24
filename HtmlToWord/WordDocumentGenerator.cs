using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using HtmlFileProcessor;

namespace HtmlToWord
{
    public class WordDocumentGenerator
    {
        private readonly Application _wordApp;
        private readonly Document _doc;
        private object _endOfDoc;
        private object _missing;

		private const string MethodPic = @"C:\WordDocImages\method_pic.gif";
		private const string PrivatePropertyPic = @"C:\WordDocImages\private_prop.gif";
		private const string PublicPropertyPic = @"C:\WordDocImages\public_prop.gif";

        public WordDocumentGenerator()
        {
            _missing = Missing.Value;
            _endOfDoc = "\\endofdoc"; //is a predefined bookmark
            _wordApp = new Application();
            _doc = _wordApp.Documents.Add(ref _missing, ref _missing, 
                ref _missing, ref _missing);
        }

        public void SaveDocument(string pathToSave)
        {
            _doc.SaveAs(ProcessSavePath(pathToSave) + "doc", true);

            _doc.Close();
            _wordApp.Application.Quit();
        }

		public void CreateTextSection(string text, int bold = 0, int spaceAfter = 6, 
			int size = 12, WdColor textColor = WdColor.wdColorBlack)
		{
			object range = _doc.Bookmarks.get_Item(ref _endOfDoc).Range;
			var titleSection = _doc.Content.Paragraphs.Add(ref range);
			titleSection.Range.Text = text;
			titleSection.Range.Font.Bold = bold;
			titleSection.Range.Font.Size = size;
			titleSection.Range.Font.Color = textColor;
			titleSection.Format.SpaceAfter = spaceAfter;
			titleSection.Range.InsertParagraphAfter();
		}

    	public void CreateConstructorsTable(IList<Constructor> constructors)
    	{
    		var rowsCount = constructors.Count + 1;
            var range = _doc.Bookmarks.get_Item(ref _endOfDoc).Range;
            var table = _doc.Tables.Add(range, rowsCount, 3, ref _missing, ref _missing);
            table.Range.Font.Bold = 0;
            table.Range.Font.Color = WdColor.wdColorBlack;
            table.Range.Font.Size = 10;
            table.Borders.Enable = 1;

            table.Cell(1, 2).Range.Text = "Name";
            table.Cell(1, 3).Range.Text = "Description";

			for (var row = 2; row <= rowsCount; row++)
			{
				var constructor = constructors[row - 2];
				table.Cell(row, 1).Range.InlineShapes.AddPicture(MethodPic);
				table.Cell(row, 2).Range.Text = constructor.Name;
				table.Cell(row, 3).Range.Text = constructor.Description;
			}

    		table.Rows[1].Range.Font.Bold = 1;
            table.Rows[1].Range.HighlightColorIndex = WdColorIndex.wdGray25;
        }

        public void CreatePropertiesTable(IList<Property> properties)
        {
        	var rowsCount = properties.Count + 1;
            var range = _doc.Bookmarks.get_Item(ref _endOfDoc).Range;
            var table = _doc.Tables.Add(range, rowsCount, 3, ref _missing, ref _missing);
            table.Range.ParagraphFormat.SpaceAfter = 6;
            table.Range.Font.Bold = 0;
        	table.Range.Font.Size = 10;
            table.Range.Font.Color = WdColor.wdColorBlack;
            table.Borders.Enable = 1;

            table.Cell(1, 2).Range.Text = "Name";
            table.Cell(1, 3).Range.Text = "Description";

			for (var row = 2; row <= rowsCount; row++)
			{
				var property = properties[row - 2];
				if (property.IsPublic)
					table.Cell(row, 1).Range.InlineShapes.AddPicture(PublicPropertyPic);
				else
					table.Cell(row, 1).Range.InlineShapes.AddPicture(PrivatePropertyPic);

				table.Cell(row, 2).Range.Text = property.Name;
				table.Cell(row, 3).Range.Text = property.Description;
			}

            table.Rows[1].Range.Font.Bold = 1;
            table.Rows[1].Range.HighlightColorIndex = WdColorIndex.wdGray25;
        }

		private static string ProcessSavePath(string savePath)
		{
			var parts = savePath.Split('.');
			var processedPath = string.Empty;
			for (var idx = 0; idx < parts.Length - 1; idx++)
				processedPath += parts[idx] + ".";

			return processedPath;
		}
    }
}
