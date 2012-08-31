namespace HtmlFileProcessor
{
    public class HtmlHeaderProcessor
    {
    	private readonly string _htmlText;

		private const string NamespaceWord = "Namespace:";
    	private const string AssemblyWord = "Assembly:";
    	private const string SyntaxSectionWord = ">Syntax<";

    	public HtmlHeaderProcessor(string htmlText)
    	{
    		_htmlText = htmlText;
    	}

    	public string FetchNamespaceInfo()
    	{
    		var namespaceValue = TextUtil.GetPureValueBetweenWords(_htmlText, NamespaceWord, AssemblyWord);
    		return NamespaceWord + namespaceValue;
    	}

    	public string FetchAssemblyInfo()
    	{
    		var assemblyValue = TextUtil.GetPureValueBetweenWords(_htmlText, AssemblyWord, SyntaxSectionWord);
    		return AssemblyWord + assemblyValue;
    	}

    	public string TitleOfControl()
    	{
    		return TextUtil.GetPureValueBetweenWords(_htmlText, "<title>", "</title>");
    	}
    }
}
