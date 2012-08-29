using System.Linq;

namespace HtmlFileProcessor
{
	public class TextUtil
	{
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
