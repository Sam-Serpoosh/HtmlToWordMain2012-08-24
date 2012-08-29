using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace HtmlToWordMain
{
    class WordDocumentGenerator
    {
        private Application _wordApp;
        private Document _doc;
        private object _endOfDoc;
        private object _missing;

        public WordDocumentGenerator()
        {
            _missing = Missing.Value;
            _endOfDoc = "\\endofdoc"; //is a predefined bookmark
            _wordApp = new Application();
            _doc = _wordApp.Documents.Add(ref _missing, ref _missing, 
                ref _missing, ref _missing);
        }

        public void SaveDocument()
        {
            CreateTextSection("Constructors", 1, 6, 16);
            CreateConstructorsTable();

            CreateTextSection("Properties", 1, 6, 16);
            CreatePropertiesTable();

            _doc.SaveAs(@"C:\TestFiles\GeneratedWordDoc.doc", true);

            _doc.Close();
            _wordApp.Application.Quit();
        }

		public void CreateTextSection(string text, int bold = 0, int spaceAfter = 6, 
			int size = 12, WdColor textColor = (WdColor)WordColor.Black)
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

    	private void CreateConstructorsTable()
        {
            var range = _doc.Bookmarks.get_Item(ref _endOfDoc).Range;
            var table = _doc.Tables.Add(range, 2, 3, ref _missing, ref _missing);
            table.Range.Font.Bold = 0;
            table.Range.Font.Color = WdColor.wdColorBlack;
            table.Range.Font.Size = 10;
            table.Borders.Enable = 1;

			const string picPathInsideTableCell = @"C:\Works with Matthew\Html to Word Doc-2012-08-24\images\next_to_methods_pic.gif";
            table.Cell(2, 1).Range.InlineShapes.AddPicture(picPathInsideTableCell);

            table.Cell(1, 2).Range.Text = "Name";
            table.Cell(1, 3).Range.Text = "Description";
            table.Cell(2, 2).Range.Text = "MMSControl()";
            table.Cell(2, 3).Range.Text = "Creates instance for MMS Control";

            table.Rows[1].Range.Font.Bold = 1;
            table.Rows[1].Range.HighlightColorIndex = WdColorIndex.wdGray25;
        }

        private void CreatePropertiesTable()
        {
            var range = _doc.Bookmarks.get_Item(ref _endOfDoc).Range;
            var table = _doc.Tables.Add(range, 2, 3, ref _missing, ref _missing);
            table.Range.ParagraphFormat.SpaceAfter = 6;
            table.Range.Font.Bold = 0;
            table.Range.Font.Color = WdColor.wdColorBlack;
            table.Borders.Enable = 1;

            const string picPathInsideTableCell = @"C:\Works with Matthew\Html to Word Doc-2012-08-24\images\next_to_property.gif";
            table.Cell(2, 1).Range.InlineShapes.AddPicture(picPathInsideTableCell);

            table.Cell(1, 2).Range.Text = "Name";
            table.Cell(1, 3).Range.Text = "Description";
            table.Cell(2, 2).Range.Text = "FileOpenButtonStyle";
            table.Cell(2, 3).Range.Text = "Style for open file button";

            table.Rows[1].Range.Font.Bold = 1;
            table.Rows[1].Range.HighlightColorIndex = WdColorIndex.wdGray25;
        }
    }

	public enum WordColor
	{
		Black = WdColor.wdColorBlack,
		Blue = WdColor.wdColorDarkBlue
	}
}
