using System.Linq;
using NUnit.Framework;

namespace HtmlFileProcessor.Test
{
	[TestFixture]
	public class HtmlPropertiesProcessorFixture
	{
		[Test]
		public void FetchMatchedPartsOfHtmlTextCaseOfOnlyOneMatch()
		{
			var htmlText =
				@"starts with Properties </tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" " + 
				@"title=""Public property"" /></td><td><a href=""1695590270.htm"">" + 
				@"FileOpenButtonStyle</a></td><td><div class=""summary"">
  Style for open file buton
  </div></td></tr><tr><td> ends with Fields";

			var propertiesProcessor = new HtmlPropertiesProcessor(htmlText);
			var propertyHtmlText = propertiesProcessor.PropertiesHtml();

			Assert.AreEqual(@"<tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""1695590270.htm"">FileOpenButtonStyle</a></td><td><div class=""summary"">
  Style for open file buton
  </div></td>", propertyHtmlText.First());
		}

		[Test]
		public void FetchMatchedPartsOfHtmlTextCaseOfMultipleMatches()
		{
			var htmlText =
				@"Starts with Properties and then it comes the Description and then </th><th class=""nameColumn"">Name</th><th class=""descriptionColumn"">Description</th></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""1695590270.htm"">FileOpenButtonStyle</a></td><td><div class=""summary"">
  Style for open file buton
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""478353029.htm"">FilePath</a></td><td><div class=""summary"">
  Path to file
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""139900315.htm"">MaxMMSLength</a></td><td><div class=""summary"">
  Max MMS text length
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""1352731343.htm"">Message</a></td><td><div class=""summary"">
  Text of MMS
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" and it ends with Fields";

			var propertyProcessor = new HtmlPropertiesProcessor(htmlText);
			var propertiesHtml = propertyProcessor.PropertiesHtml();

			Assert.AreEqual(4, propertiesHtml.Count);
		}

		[Test]
		public void ProcessSinglePropertyAccordingToHtmlInformationForIt()
		{
			var htmlProperty =
				@"<tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""1695590270.htm"">FileOpenButtonStyle</a></td><td><div class=""summary"">
  Style for open file buton
  </div></td>";

			var propertyProcessor = new HtmlPropertiesProcessor(htmlProperty);
			var property = propertyProcessor.CreateProperty(htmlProperty);

			Assert.AreEqual(new Property("FileOpenButtonStyle", "Style for open file buton", true), property);
		}

		[Test]
		public void ProcessingSinglePropertyAccordingToHtmlInformationForItWhenThereIsNoDescription()
		{
			var htmlProperty =
				@"<tr><td><img src=""../icons/privproperty.gif"" alt=""Private property"" " + 
				@"title=""Private property"" /></td><td><a href=""1548552129.htm"">" + 
				@"Presenter</a></td><td />";

			var propertyProcessor = new HtmlPropertiesProcessor(htmlProperty);
			var property = propertyProcessor.CreateProperty(htmlProperty);

			Assert.AreEqual(new Property("Presenter", "", false), property);
		}

		[Test]
		public void GetsAllThePropertiesAccordingToHtmlText()
		{
			var htmlText =
				@"class=""LW_CollapsibleArea_Title"">Properties</h2><div class=""LW_CollapsibleArea_HrDiv""><hr class=""LW_CollapsibleArea_Hr"" /></div></div><a id=""propertySection""><!----></a><table id=""typeList"" class=""members""><tr><th class=""iconColumn"">
           
        </th><th class=""nameColumn"">Name</th><th class=""descriptionColumn"">Description</th></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""1695590270.htm"">FileOpenButtonStyle</a></td><td><div class=""summary"">
  Style for open file buton
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""478353029.htm"">FilePath</a></td><td><div class=""summary"">
  Path to file
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""139900315.htm"">MaxMMSLength</a></td><td><div class=""summary"">
  Max MMS text length
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""1352731343.htm"">Message</a></td><td><div class=""summary"">
  Text of MMS
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""557263916.htm"">MMSTextStyle</a></td><td><div class=""summary"">
  Style for textBox with MMS
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""1967299635.htm"">PhoneNumbers</a></td><td><div class=""summary"">
  Comma-separated list of phone numbers specified by user
  </div></td></tr><tr><td><img src=""../icons/pubproperty.gif"" alt=""Public property"" title=""Public property"" /></td><td><a href=""1692139523.htm"">PhoneNumberStyle</a></td><td><div class=""summary"">
  Style for textBox with phone numbers
  </div></td></tr><tr><td><img src=""../icons/privproperty.gif"" alt=""Private property"" title=""Private property"" /></td><td><a href=""1548552129.htm"">Presenter</a></td><td /></tr></table></div><div class=""LW_CollapsibleArea_Container""><div class=""LW_CollapsibleArea_TitleDiv""><h2 class=""LW_CollapsibleArea_Title"">Fields</h2>";

			var propertyProcessor = new HtmlPropertiesProcessor(htmlText);
			var properties = propertyProcessor.GetAllProperties();
			
			Assert.AreEqual(8, properties.Count);
			Assert.AreEqual(new Property("FilePath", "Path to file", true), properties[1]);
		}
	}
}
