using System;
using HtmlFileProcessor;
using Microsoft.Office.Interop.Word;

namespace HtmlToWordMain
{
    class Program
    {
        static void Main()
        {
			var wordGenerator = new WordDocumentGenerator();
			var contentRetriever = new RetrieveFileContent(@"C:\TestFiles\MMSControl.htm");
        	var content = contentRetriever.FileContent();

        	var htmlProcessor = new HtmlProcessor(content);
        	var title = htmlProcessor.TitleOfControl();
        	var namespaceInfo = htmlProcessor.FetchNamespaceInfo();
        	var assemblyInfo = htmlProcessor.FetchAssemblyInfo();

        	wordGenerator.CreateTextSection(title, 1, 10, 18, (WdColor)WordColor.Blue);
			wordGenerator.CreateTextSection(namespaceInfo, 1, 0, 13);
			wordGenerator.CreateTextSection(assemblyInfo, 1, 25, 13);
			wordGenerator.SaveDocument();
        }
    }
}
