using NUnit.Framework;

namespace HtmlFileProcessor.Test
{
	[TestFixture]
	public class TextUtilFixture
	{
		[Test]
		public void IgnoresFromOpenningAngleBracketToClosingOne()
		{
			const string controlName = "MMSControl";
			const string htmlText = "<span class=\"identifier\">" + controlName + "</span>";
			var value = TextUtil.ValueWithoutHtmlPeripherals(htmlText);
			Assert.AreEqual(controlName, value);
		}

		[Test]
		public void FetchTextBetweenTwoWords()
		{
			var text = "hello how you doing </sljflksdjf. ldj> bye";
			var fetched = TextUtil.FetchTextBetween(text, "hello", "bye");
			Assert.AreEqual(" how you doing </sljflksdjf. ldj> ", fetched);
		}

		[Test]
		public void FiltersNonEmptyValuesInText()
		{
			var text = "   sample text   here";
			var filtered = TextUtil.FilterNonEmptyValues(text);
			Assert.AreEqual("sample text here", filtered);
		}
	}
}
