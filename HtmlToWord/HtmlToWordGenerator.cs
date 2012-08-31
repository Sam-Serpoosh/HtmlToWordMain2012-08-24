using HtmlFileProcessor;
using Microsoft.Office.Interop.Word;

namespace HtmlToWord
{
	public class HtmlToWordGenerator
	{
		private readonly string _htmlDocFilePath;
		private readonly string _htmlFileContent;
		private readonly WordDocumentGenerator _wordGenerator;

		public HtmlToWordGenerator(string htmlDocFilePath)
		{
			_wordGenerator = new WordDocumentGenerator();
			var _htmlFileContentRetriever = new RetrieveFileContent(htmlDocFilePath);
			_htmlFileContent = _htmlFileContentRetriever.FileContent();
			_htmlDocFilePath = htmlDocFilePath;
		}

		public void GenerateTheWordDocumentForHtmlDoc()
		{
			CreateHeaderSection();
			CreateSyntaxSection();
			CreateConstructorSection();
			CreatePropertiesSection();

			SaveTheDocument();
		}

		private void CreateHeaderSection()
		{
			var htmlHeaderProcessor = new HtmlHeaderProcessor(_htmlFileContent);
			var title = htmlHeaderProcessor.TitleOfControl();
			var namespaceInfo = htmlHeaderProcessor.FetchNamespaceInfo();
			var assemblyInfo = htmlHeaderProcessor.FetchAssemblyInfo();

			_wordGenerator.CreateTextSection(title, 1, 10, 20, WdColor.wdColorDarkBlue);
			_wordGenerator.CreateTextSection(namespaceInfo, 1, 0, 13);
			_wordGenerator.CreateTextSection(assemblyInfo, 1, 25, 13);
		}

		private void CreateSyntaxSection()
		{
			var htmlSyntaxProcessor = new HtmlSyntaxProcessor(_htmlFileContent);
			var csharpCode = htmlSyntaxProcessor.CsharpCode();
			var vbCode = htmlSyntaxProcessor.VisualBasicCode();
			var cppCode = htmlSyntaxProcessor.CppCode();
			var memberSentence = htmlSyntaxProcessor.MemberSentence();

			_wordGenerator.CreateTextSection("Syntax", 1, 10, 16, WdColor.wdColorDarkBlue);
			_wordGenerator.CreateTextSection(csharpCode, 1, 6, 13);
			_wordGenerator.CreateTextSection(vbCode, 1, 6, 13);
			_wordGenerator.CreateTextSection(cppCode, 1, 10, 13);
			_wordGenerator.CreateTextSection(memberSentence, 0, 12);
		}

		private void CreateConstructorSection()
		{
			var htmlConstructorProcessor = new HtmlConstructorProcessor(_htmlFileContent);
			var constructors = htmlConstructorProcessor.GetAllConstructors();

			_wordGenerator.CreateTextSection("Constructors", 1, 6, 16, WdColor.wdColorDarkBlue);
			_wordGenerator.CreateConstructorsTable(constructors);
		}

		private void CreatePropertiesSection()
		{
			var htmlPropertiesProcessor = new HtmlPropertiesProcessor(_htmlFileContent);
			var properties = htmlPropertiesProcessor.GetAllProperties();

			_wordGenerator.CreateTextSection("Properties", 1, 6, 16, WdColor.wdColorDarkBlue);
			_wordGenerator.CreatePropertiesTable(properties);
		}

		private void SaveTheDocument()
		{
			_wordGenerator.SaveDocument(_htmlDocFilePath);
		}
	}
}
