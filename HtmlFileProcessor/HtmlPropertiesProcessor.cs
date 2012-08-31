using System;
using System.Linq;
using System.Collections.Generic;

namespace HtmlFileProcessor
{
	public class HtmlPropertiesProcessor
	{
		private string _htmlText;

		private const string PropertiesWord = "Properties";
		private const string FieldsWord = "Fields";
		private const string PublicPropertyPhrase = "Public property";

		public HtmlPropertiesProcessor(string htmlText)
		{
			_htmlText = htmlText;
		}

		public IList<Property> GetAllProperties()
		{
			var propertiesHtmlText = PropertiesHtml();
			var properties = new List<Property>();
			foreach (var propertyHtml in propertiesHtmlText)
				properties.Add(CreateProperty(propertyHtml));

			return properties;
		}

		public IList<string> PropertiesHtml()
		{
			var propertiesWholeSection = WholePropertiesSection();
			var parts = propertiesWholeSection.Split(new[] { "</tr>" }, Int32.MaxValue,
				StringSplitOptions.None).ToList();
			parts.RemoveAt(0);
			parts.RemoveAt(parts.Count - 1);

			return parts;
		}

		public Property CreateProperty(string htmlProperty)
		{
			var allPropertyValues = TextUtil.GetPureValue(htmlProperty);
			var splittedValues = allPropertyValues.Split(' ');

			var propertyName = splittedValues.First();
			var descriptionParts = new List<string>();
			for (var i = 1; i < splittedValues.Length; i++)
				descriptionParts.Add(splittedValues[i]);
			var description = string.Join(" ", descriptionParts.ToArray());
			var isPublic = htmlProperty.Contains(PublicPropertyPhrase);

			return new Property(propertyName, description, isPublic);
		}

		private string WholePropertiesSection()
		{
			return TextUtil.FetchTextBetween(_htmlText, PropertiesWord, FieldsWord);
		}
	}
}
