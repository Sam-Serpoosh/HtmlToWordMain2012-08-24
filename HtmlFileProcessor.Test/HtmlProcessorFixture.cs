using NUnit.Framework;

namespace HtmlFileProcessor.Test
{
    [TestFixture]
    public class HtmlProcessorFixture
    {
        [Test]
        public void IgnoresFromOpenningAngleBracketToClosingOne()
        {
            const string controlName = "MMSControl";
            const string htmlText = "<span class=\"identifier\">" + controlName + "</span>";
            var htmlProcessor = new HtmlProcessor(htmlText);
            var value = htmlProcessor.ValueWithoutHtmlPeripherals(htmlText);
            Assert.AreEqual(controlName, value);
        }

		[Test]
		public void GetsTheTitleOfTheControl()
		{
			const string htmlText = @"<meta name=""save"" content=""history"" />
    <title>MMSControl Class</title>";

			var htmlProcessor = new HtmlProcessor(htmlText);
			var title = htmlProcessor.TitleOfControl();

			Assert.AreEqual("MMSControl Class", title);
		}

    	[Test]
		public void FetchingNamespaceInformation()
		{
			const string htmlText = @"<p />
    <b>Namespace:</b> 
   <a href=""1540481632.htm"">ATT.Controls</a><br />
    <b>Assembly:</b>
   <span sdata=""assembly""";

			var htmlProcessor = new HtmlProcessor(htmlText);
			var namespaceInfo = htmlProcessor.FetchNamespaceInfo();

			Assert.AreEqual("Namespace: ATT.Controls", namespaceInfo);
		}

		[Test]
		public void FetchAssmeblyInformation()
		{
			const string htmlText =
				@"><br />
    <b>Assembly:</b>
   <span sdata=""assembly"">ATT.Controls</span> (in ATT.Controls.dll)<div class=""LW_" + 
@"CollapsibleArea_Container""><div class=""LW_CollapsibleArea_TitleDiv"">" + 
@"<h2 class=""LW_CollapsibleArea_Title"">Syntax</h2><";

			var htmlProcessor = new HtmlProcessor(htmlText);
			var assemblyInfo = htmlProcessor.FetchAssemblyInfo();

			Assert.AreEqual("Assembly: ATT.Controls (in ATT.Controls.dll)", assemblyInfo);
		}
    }
}
