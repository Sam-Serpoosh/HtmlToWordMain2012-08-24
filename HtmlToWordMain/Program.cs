namespace HtmlToWordMain
{
    class Program
    {
        static void Main()
        {
            var wordGenerator = new WordDocumentGenerator();
            wordGenerator.SaveDocument();
        }

        //static void CreateDocument()
        //{
        //    object oMissing = Missing.Value;
        //    object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

        //    //Start Word and create a new document.
        //    //Word._Application oWord;
        //    //Word._Document oDoc;
        //    var oWord = new Word.Application();
        //    //oWord.Visible = true;
        //    var oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
        //        ref oMissing, ref oMissing);

        //    //Insert a paragraph at the beginning of the document.
        //    //var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
        //    //oPara1.Range.Text = "Heading 1";
        //    //oPara1.Range.Font.Bold = 1;
        //    //oPara1.Format.SpaceAfter = 12;    //24 pt spacing after paragraph.
        //    //oPara1.Range.InsertParagraphAfter();

        //    //Insert a paragraph at the end of the document.
        //    object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //    var oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
        //    oPara2.Range.Text = "Constructors";
        //    oPara2.Range.Font.Bold = 1;
        //    oPara2.Format.SpaceAfter = 6;
        //    oPara2.Range.InsertParagraphAfter();

        //    //Insert another paragraph.
        //    //Word.Paragraph oPara3;
        //    //oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //    //oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
        //    //oPara3.Range.Text = "This is a sentence of normal text. Now here is a table:";
        //    //oPara3.Range.Font.Bold = 0;
        //    //oPara3.Format.SpaceAfter = 24;
        //    //oPara3.Range.InsertParagraphAfter();

        //    //Insert a 3 x 5 table, fill it with data, and make the first row
        //    //bold and italic.
        //    var wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //    var oTable = oDoc.Tables.Add(wrdRng, 2, 3, ref oMissing, ref oMissing);
        //    oTable.Range.ParagraphFormat.SpaceAfter = 6;
        //    oTable.Borders.Enable = 1;

        //    var picPathInsideTableCell = @"C:\Works with Matthew\Html to Word Doc-2012-08-24\images\next_to_methods_pic.gif";
        //    oTable.Cell(2, 1).Range.InlineShapes.AddPicture(picPathInsideTableCell);

        //    oTable.Cell(1, 2).Range.Text = "Name";
        //    oTable.Cell(1, 3).Range.Text = "Description";
        //    oTable.Cell(2, 2).Range.Text = "MMSControl()";
        //    oTable.Cell(2, 3).Range.Text = "Creates instance for MMS Control";

        //    //oTable.Rows[1].Range.Font.Bold = 1;
        //    //oTable.Rows[1].Range.Font.Italic = 1;

        //    //object oPos;
        //    //double dPos = oWord.InchesToPoints(7);
        //    //oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
        //    //do
        //    //{
        //    //    wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //    //    wrdRng.ParagraphFormat.SpaceAfter = 6;
        //    //    wrdRng.InsertAfter("A line of text");
        //    //    wrdRng.InsertParagraphAfter();
        //    //    oPos = wrdRng.get_Information
        //    //                   (Word.WdInformation.wdVerticalPositionRelativeToPage);
        //    //}
        //    //while (dPos >= Convert.ToDouble(oPos));

        //    //var picturePath = @"C:\Works with Matthew\Html to Word Doc-2012-08-24\images\next_to_methods_pic.gif";
        //    //oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InlineShapes.AddPicture(picturePath);

        //    oDoc.SaveAs(@"C:\TestFiles\GeneratedWordDoc.doc", true);

        //    oDoc.Close();
        //    oWord.Application.Quit();
        //}
    }
}
