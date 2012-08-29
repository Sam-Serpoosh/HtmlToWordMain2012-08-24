using System;
using System.Linq;

namespace HtmlFileProcessor
{
    public class HtmlProcessor
    {
    	private readonly string _htmlText;

		private const string NamespaceWord = "Namespace:";
    	private const string AssemblyWord = "Assembly:";
    	private const string SyntaxSectionWord = ">Syntax<";

    	public HtmlProcessor(string htmlText)
    	{
    		_htmlText = htmlText;
    	}

        public string ValueWithoutHtmlPeripherals(string textInHtmlFormat)
        {
        	var extractedText = string.Empty;
        	var shouldBeAdded = true;
			foreach (var ch in textInHtmlFormat)
			{
				if (ch.Equals('<'))
					shouldBeAdded = false;
				if (ch.Equals('>'))
					shouldBeAdded = true;
				if (shouldBeAdded && !ch.Equals('>'))
					extractedText += ch.ToString();
			}

        	return extractedText.Replace("\r\n", string.Empty);
        }

    	public string FetchNamespaceInfo()
    	{
    		var namespaceValue = GetValueBetweenWords(NamespaceWord, AssemblyWord);
    		return NamespaceWord + namespaceValue;
    	}

    	public string FetchAssemblyInfo()
    	{
    		var assemblyValue = GetValueBetweenWords(AssemblyWord, SyntaxSectionWord);
    		return AssemblyWord + assemblyValue;
    	}

    	public string TitleOfControl()
    	{
    		return GetValueBetweenWords("<title>", "</title>");
    	}

		private string GetValueBetweenWords(string startingWord, string endingWord)
		{
			var excerptText = TextUtil.FetchTextBetween(_htmlText, startingWord, endingWord);
			var innerText = ValueWithoutHtmlPeripherals(excerptText);
			var value = TextUtil.FilterNonEmptyValues(innerText);

			return value;
		}
    }
}
