using System.Linq;

namespace HtmlFileProcessor
{
	public class TextUtil
	{
		public static string GetPureValueBetweenWords(string text, string startingWord, string endingWord)
		{
			var excerptText = FetchTextBetween(text, startingWord, endingWord);
			var innerText = ValueWithoutHtmlPeripherals(excerptText);
			var value = FilterNonEmptyValues(innerText);

			return value;
		}

		public static string GetPureValue(string text)
		{
			var innerText = ValueWithoutHtmlPeripherals(text);
			return FilterNonEmptyValues(innerText);
		}

		public static string ValueWithoutHtmlPeripherals(string textInHtmlFormat)
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

			return extractedText.Replace("\r\n", string.Empty).Replace("\t", string.Empty);
		}

		public static string FetchTextBetween(string text, string startWord, string endWord)
		{
			var startIndex = text.IndexOf(startWord) + startWord.Length;
			var endIndex = text.IndexOf(endWord);
			var length = endIndex - startIndex;
			return text.Substring(startIndex, length);
		}

		public static string FilterNonEmptyValues(string text)
		{
			var allValues = text.Split(' ');
			var allNonEmptyValues = allValues.Where(str => !string.IsNullOrEmpty(str)).ToArray();
			return string.Join(" ", allNonEmptyValues);
		}
	}
}
