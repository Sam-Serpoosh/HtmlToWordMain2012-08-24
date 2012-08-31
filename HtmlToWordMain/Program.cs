using HtmlToWord;

namespace HtmlToWordMain
{
    class Program
    {
        static void Main()
        {
			new HtmlToWordGenerator(@"C:\TestFiles\MMSControl.htm").
				GenerateTheWordDocumentForHtmlDoc();
        }
    }
}
