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

        	var htmlHeaderProcessor = new HtmlHeaderProcessor(content);
        	var title = htmlHeaderProcessor.TitleOfControl();
        	var namespaceInfo = htmlHeaderProcessor.FetchNamespaceInfo();
        	var assemblyInfo = htmlHeaderProcessor.FetchAssemblyInfo();

        	var htmlSyntaxProcessor = new HtmlSyntaxProcessor(content);
        	var syntaxTitle = "Syntax";
        	var csharpCode = htmlSyntaxProcessor.CsharpCode();
        	var vbCode = htmlSyntaxProcessor.VisualBasicCode();
        	var cppCode = htmlSyntaxProcessor.CppCode();
        	var memberSentence = htmlSyntaxProcessor.MemberSentence();

        	wordGenerator.CreateTextSection(title, 1, 10, 20, (WdColor)WordColor.Blue);
			wordGenerator.CreateTextSection(namespaceInfo, 1, 0, 13);
			wordGenerator.CreateTextSection(assemblyInfo, 1, 25, 13);

			wordGenerator.CreateTextSection(syntaxTitle, 1, 10, 16, (WdColor)WordColor.Blue);
			wordGenerator.CreateTextSection(csharpCode, 1, 6, 13);
			wordGenerator.CreateTextSection(vbCode, 1, 6, 13);
			wordGenerator.CreateTextSection(cppCode, 1, 10, 13);
			wordGenerator.CreateTextSection(memberSentence, 0, 12);

			wordGenerator.SaveDocument();
        }
    }
}
