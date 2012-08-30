using NUnit.Framework;

namespace HtmlFileProcessor.Test
{
    [TestFixture]
    public class HtmlHeaderProcessorFixture
    {
		[Test]
		public void GetsTheTitleOfTheControl()
		{
			const string htmlText = @"<meta name=""save"" content=""history"" />
    <title>MMSControl Class</title>";

			var htmlProcessor = new HtmlHeaderProcessor(htmlText);
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

			var htmlProcessor = new HtmlHeaderProcessor(htmlText);
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

			var htmlProcessor = new HtmlHeaderProcessor(htmlText);
			var assemblyInfo = htmlProcessor.FetchAssemblyInfo();

			Assert.AreEqual("Assembly: ATT.Controls (in ATT.Controls.dll)", assemblyInfo);
		}
    }
}
