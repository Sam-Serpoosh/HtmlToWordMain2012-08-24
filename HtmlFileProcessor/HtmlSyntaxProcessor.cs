namespace HtmlFileProcessor
{
	public class HtmlSyntaxProcessor
	{
		private readonly string _htmlText;

		private const string CsharpCodeId = "\"CSharpCodeId\"";
		private const string VisualBasicCodeId = "\"VisualBasicCodeId\"";
		private const string CppCodeWord = "\"ManagedCPlusPlusCode\"";
		private const string CppCodeId = "\"ManagedCPlusPlusCodeId\"";
		private const string Constructors = "Constructors";

		public HtmlSyntaxProcessor(string htmlText)
		{
			_htmlText = htmlText;
		}

		public string CsharpCode()
		{
			var csharpCode = TextUtil.GetPureValueBetweenWords(_htmlText, 
				CsharpCodeId, VisualBasicCodeId);
			return "C# -> " + csharpCode;
		}

		public string VisualBasicCode()
		{
			var vbCode = TextUtil.GetPureValueBetweenWords(_htmlText, 
				VisualBasicCodeId, CppCodeId).Replace("_", string.Empty); //not sure about this replacement, did it according to sample codes in internet for VB.
			return "VB -> " + vbCode;
		}

		public string CppCode()
		{
			var excerpted = TextUtil.FetchTextBetween(_htmlText, CppCodeWord, Constructors);
			var cppCode = TextUtil.GetPureValueBetweenWords(excerpted, CppCodeId, "<p>");

			return "C++ -> " + cppCode;
		}

		public string MemberSentence()
		{
			var excerpted = TextUtil.FetchTextBetween(_htmlText, CppCodeWord, Constructors);
			var memberSentence = TextUtil.GetPureValueBetweenWords(excerpted, "<p>", "</p>");

			return memberSentence;
		}
	}
}