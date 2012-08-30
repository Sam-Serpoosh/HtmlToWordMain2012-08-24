using NUnit.Framework;

namespace HtmlFileProcessor.Test
{
	[TestFixture]
	public class HtmlSyntaxProcessorFixture
	{
		[Test]
		public void RetrievesCSharpCodeSyntax()
		{
			var htmlText = @"class=""CodeSnippetContainerCode CSharpCode"" " +
				@"id=""CSharpCodeId""><pre xml:space=""preserve"" class=""libCScode"">" + 
				@"<span class=""keyword"">public</span> <span class=""keyword"">sealed" + 
				@"</span> <span class=""keyword"">class</span> <span class=""identifier"">" + 
				@"MMSControl</span> : <span class=""nolink"">ControlBase</span></pre>" + 
				@"</div><div class=""CodeSnippetContainerCode VisualBasicCode"" " + 
				@"id=""VisualBasicCodeId""><pre xml:space=""preserve""";

			var syntaxProcessor = new HtmlSyntaxProcessor(htmlText);
			var csharpCode = syntaxProcessor.CsharpCode();

			Assert.AreEqual("C# -> public sealed class MMSControl : ControlBase", csharpCode);
		}

		[Test]
		public void RetrievesVisualBasicCode()
		{
			var htmlText = @"VisualBasicCode"" id=""VisualBasicCodeId""><pre " + 
				@"xml:space=""preserve"" class=""libCScode""><span class=""keyword"">" + 
				@"Public</span> <span class=""keyword"">NotInheritable</span> " + 
				@"<span class=""keyword"">Class</span> <span class=""identifier"">" + 
				@"MMSControl</span> _
				<span class=""keyword"">Inherits</span> <span class=""nolink"">" + 
				@"ControlBase</span></pre></div><div class=""CodeSnippetContainerCode " + 
				@"ManagedCPlusPlusCode"" id=""ManagedCPlusPlusCodeId""><pre " + 
				@"xml:space=""preserve""";

			var syntaxProcessor = new HtmlSyntaxProcessor(htmlText);
			var vbCode = syntaxProcessor.VisualBasicCode();

			Assert.AreEqual("VB -> Public NotInheritable Class MMSControl Inherits ControlBase", 
				vbCode);
		}

		[Test]
		public void RetrieveCppCode()
		{
			var htmlText = @"ManagedCPlusPlusCode"" id=""ManagedCPlusPlusCodeId"">" + 
				@"<pre xml:space=""preserve"" class=""libCScode""><span " + 
				@"class=""keyword"">public</span> <span class=""keyword"">ref class" + 
				@"</span> <span class=""identifier"">MMSControl</span> <span " + 
				@"class=""keyword"">sealed</span> : <span class=""keyword"">public</span> " + 
				@"<span class=""nolink"">ControlBase</span></pre></div></div></div>" + 
				@"</div></div><p>The MMSControl type exposes the following members.</p>" + 
				@"<div class=""LW_CollapsibleArea_Container""><div " + 
				@"class=""LW_CollapsibleArea_TitleDiv""><h2 " + 
				@"class=""LW_CollapsibleArea_Title"">Constructors</h2><div " + 
				@"class=""LW_CollapsibleArea_HrDiv"">";

			var syntaxProcessor = new HtmlSyntaxProcessor(htmlText);
			var cppCode = syntaxProcessor.CppCode();

			Assert.AreEqual("C++ -> public ref class MMSControl sealed : public ControlBase", 
				cppCode);
		}

		[Test]
		public void RetrieveMemberExposingSentence()
		{
			var htmlText = @"ManagedCPlusPlusCode"" id=""ManagedCPlusPlusCodeId"">" +
				@"<pre xml:space=""preserve"" class=""libCScode""><span " +
				@"class=""keyword"">public</span> <span class=""keyword"">ref class" +
				@"</span> <span class=""identifier"">MMSControl</span> <span " +
				@"class=""keyword"">sealed</span> : <span class=""keyword"">public</span> " +
				@"<span class=""nolink"">ControlBase</span></pre></div></div></div>" +
				@"</div></div><p>The MMSControl type exposes the following members.</p>" +
				@"<div class=""LW_CollapsibleArea_Container""><div " +
				@"class=""LW_CollapsibleArea_TitleDiv""><h2 " +
				@"class=""LW_CollapsibleArea_Title"">Constructors</h2><div " +
				@"class=""LW_CollapsibleArea_HrDiv"">";

			var syntaxProcessor = new HtmlSyntaxProcessor(htmlText);
			var memberSentence = syntaxProcessor.MemberSentence();

			Assert.AreEqual("The MMSControl type exposes the following members.",
				memberSentence);
		}
	}
}
