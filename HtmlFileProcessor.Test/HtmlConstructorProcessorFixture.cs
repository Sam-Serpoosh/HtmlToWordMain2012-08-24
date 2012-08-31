using System.Linq;
using NUnit.Framework;

namespace HtmlFileProcessor.Test
{
	[TestFixture]
	public class HtmlConstructorProcessorFixture
	{
		[Test]
		public void FetchTheRelatedSectionOfHtmlTextToConstructors()
		{
			var htmlText = @"=""LW_CollapsibleArea_Title"">Constructors</h2><div class=""LW_CollapsibleArea_HrDiv""><hr class=""LW_CollapsibleArea_Hr"" /></div></div><a id=""constructorSection""><!----></a><table id=""typeList"" class=""members""><tr><th class=""iconColumn"">
           
        </th><th class=""nameColumn"">Name</th><th class=""descriptionColumn"">Description</th></tr><tr><td><img src=""../icons/pubmethod.gif"" alt=""Public method"" title=""Public method"" /></td><td><a href=""118686440.htm"">MMSControl<span class=""languageSpecificText""><span class=""cs"">()</span><span class=""cpp"">()</span><span class=""nu"">()</span><span class=""fs"">()</span></span></a></td><td><div class=""summary"">
  Creates instance of <span class=""nolink"">[MMSControl]</span></div></td></tr></table></div><div class=""LW_CollapsibleArea_Container""><div class=""LW_CollapsibleArea_TitleDiv""><h2 class=""LW_CollapsibleArea_Title"">Properties</h2><div class=""LW_CollapsibleArea_HrDiv""";

			var constructorProcessor = new HtmlConstructorProcessor(htmlText);
			var constructorSection = constructorProcessor.WholeConstructorSection();

			Assert.AreEqual(@"</h2><div class=""LW_CollapsibleArea_HrDiv""><hr class=""LW_CollapsibleArea_Hr"" /></div></div><a id=""constructorSection""><!----></a><table id=""typeList"" class=""members""><tr><th class=""iconColumn"">
           
        </th><th class=""nameColumn"">Name</th><th class=""descriptionColumn"">Description</th></tr><tr><td><img src=""../icons/pubmethod.gif"" alt=""Public method"" title=""Public method"" /></td><td><a href=""118686440.htm"">MMSControl<span class=""languageSpecificText""><span class=""cs"">()</span><span class=""cpp"">()</span><span class=""nu"">()</span><span class=""fs"">()</span></span></a></td><td><div class=""summary"">
  Creates instance of <span class=""nolink"">[MMSControl]</span></div></td></tr></table></div><div class=""LW_CollapsibleArea_Container""><div class=""LW_CollapsibleArea_TitleDiv""><h2 class=""LW_CollapsibleArea_Title"">", constructorSection);
		}

		[Test]
		public void GetConstructorsHtmlSectionsSeparately()
		{
			var htmlText = @"=""LW_CollapsibleArea_Title"">Constructors</h2><div class=""LW_CollapsibleArea_HrDiv""><hr class=""LW_CollapsibleArea_Hr"" /></div></div><a id=""constructorSection""><!----></a><table id=""typeList"" class=""members""><tr><th class=""iconColumn"">
           
        </th><th class=""nameColumn"">Name</th><th class=""descriptionColumn"">Description</th></tr><tr><td><img src=""../icons/pubmethod.gif"" alt=""Public method"" title=""Public method"" /></td><td><a href=""118686440.htm"">MMSControl<span class=""languageSpecificText""><span class=""cs"">()</span><span class=""cpp"">()</span><span class=""nu"">()</span><span class=""fs"">()</span></span></a></td><td><div class=""summary"">
  Creates instance of <span class=""nolink"">[MMSControl]</span></div></td></tr></table></div><div class=""LW_CollapsibleArea_Container""><div class=""LW_CollapsibleArea_TitleDiv""><h2 class=""LW_CollapsibleArea_Title"">Properties</h2><div class=""LW_CollapsibleArea_HrDiv""";

			var constructorProcessor = new HtmlConstructorProcessor(htmlText);
			var constructorsHtmlSections = constructorProcessor.AllConstructorsHtmlSection();

			Assert.AreEqual(1, constructorsHtmlSections.Count);
			Assert.AreEqual(@"<tr><td><img src=""../icons/pubmethod.gif"" alt=""Public method"" title=""Public method"" /></td><td><a href=""118686440.htm"">MMSControl<span class=""languageSpecificText""><span class=""cs"">()</span><span class=""cpp"">()</span><span class=""nu"">()</span><span class=""fs"">()</span></span></a></td><td><div class=""summary"">
  Creates instance of <span class=""nolink"">[MMSControl]</span></div></td>", constructorsHtmlSections.First());
		}

		[Test]
		public void CreatesConstructorStructBasedOnConstructorHtml()
		{
			var htmlText =
				@"<tr><td><img src=""../icons/pubmethod.gif"" alt=""Public method"" title=""Public method"" /></td><td><a href=""118686440.htm"">MMSControl<span class=""languageSpecificText""><span class=""cs"">()</span><span class=""cpp"">()</span><span class=""nu"">()</span><span class=""fs"">()</span></span></a></td><td><div class=""summary"">
  Creates instance of <span class=""nolink"">[MMSControl]</span></div></td>";

			var constructorProcessor = new HtmlConstructorProcessor(htmlText);
			var constructor = constructorProcessor.CreateConstructor(htmlText);

			Assert.AreEqual(new Constructor("MMSControl()", 
				"Creates instance of [MMSControl]"), constructor);
		}

		[Test]
		public void ProcessesConstructorName()
		{
			var constructorProcessor = new HtmlConstructorProcessor(string.Empty);
			var processedName = constructorProcessor.ProcessConstructorName("MMSControl()()()");

			Assert.AreEqual("MMSControl()", processedName);
		}

		[Test]
		public void GetsAllTheConstructors()
		{
			var htmlText = @"=""LW_CollapsibleArea_Title"">Constructors</h2><div class=""LW_CollapsibleArea_HrDiv""><hr class=""LW_CollapsibleArea_Hr"" /></div></div><a id=""constructorSection""><!----></a><table id=""typeList"" class=""members""><tr><th class=""iconColumn"">
           
        </th><th class=""nameColumn"">Name</th><th class=""descriptionColumn"">Description</th></tr><tr><td><img src=""../icons/pubmethod.gif"" alt=""Public method"" title=""Public method"" /></td><td><a href=""118686440.htm"">MMSControl<span class=""languageSpecificText""><span class=""cs"">()</span><span class=""cpp"">()</span><span class=""nu"">()</span><span class=""fs"">()</span></span></a></td><td><div class=""summary"">
  Creates instance of <span class=""nolink"">[MMSControl]</span></div></td></tr></table></div><div class=""LW_CollapsibleArea_Container""><div class=""LW_CollapsibleArea_TitleDiv""><h2 class=""LW_CollapsibleArea_Title"">Properties</h2><div class=""LW_CollapsibleArea_HrDiv""";

			var constructorProcessor = new HtmlConstructorProcessor(htmlText);
			var constructors = constructorProcessor.GetAllConstructors();

			Assert.AreEqual(1, constructors.Count);
			Assert.AreEqual(new Constructor("MMSControl()", 
				"Creates instance of [MMSControl]"), constructors.First());
		}
	}
}
