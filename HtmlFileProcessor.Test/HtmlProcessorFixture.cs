using NUnit.Framework;

namespace HtmlFileProcessor.Test
{
    [TestFixture]
    public class HtmlProcessorFixture
    {
        [Test]
        public void IgnoresFromOpenningAngleBracketToClosingOne()
        {
            var controlName = "MMSControl";
            var htmlText = "<span class=\"identifier\">" + controlName + "</span>";
            var htmlProcessor = new HtmlProcessor();
            var value = htmlProcessor.ExtractValueOut(htmlText);
            Assert.AreEqual(controlName, value);
        }
    }
}
