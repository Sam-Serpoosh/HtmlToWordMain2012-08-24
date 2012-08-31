using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlFileProcessor
{
	public class HtmlConstructorProcessor
	{
		private string _htmlText;

		private const string ConstructorWord = "Constructors";
		private const string PropertiesWord = "Properties";

		public HtmlConstructorProcessor(string htmlText)
		{
			_htmlText = htmlText;
		}

		public IList<Constructor> GetAllConstructors()
		{
			var constructorsHtmls = AllConstructorsHtmlSection();
			var constructors = new List<Constructor>();
			foreach (var htmlConstructor in constructorsHtmls)
				constructors.Add(CreateConstructor(htmlConstructor));

			return constructors;
		}

		internal string WholeConstructorSection()
		{
			return TextUtil.FetchTextBetween(_htmlText, ConstructorWord, PropertiesWord);
		}

		internal IList<string> AllConstructorsHtmlSection()
		{
			var constructorsWholeSection = WholeConstructorSection();
			var constructors = constructorsWholeSection.Split(new[] { "</tr>" }, Int32.MaxValue,
				StringSplitOptions.None).ToList();
			constructors.RemoveAt(0);
			constructors.RemoveAt(constructors.Count - 1);

			return constructors;
		}

		internal Constructor CreateConstructor(string htmlConstructor)
		{
			var allPropertyValues = TextUtil.GetPureValue(htmlConstructor);
			var splittedValues = allPropertyValues.Split(' ');

			var constructorName = ProcessConstructorName(splittedValues.First());
			var descriptionParts = new List<string>();
			for (var i = 1; i < splittedValues.Length; i++)
				descriptionParts.Add(splittedValues[i]);
			var description = string.Join(" ", descriptionParts.ToArray());

			return new Constructor(constructorName, description);
		}

		internal string ProcessConstructorName(string constructorName)
		{
			var processedName = string.Empty;
			foreach (var ch in constructorName)
				if (!ch.Equals(')'))
					processedName += ch.ToString();
				else
					break;

			return processedName + ")";
		}
	}
}
