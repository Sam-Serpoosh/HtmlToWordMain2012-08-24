namespace HtmlFileProcessor
{
    public class HtmlProcessor
    {
        public string ExtractValueOut(string htmlText)
        {
        	var extractedText = string.Empty;
        	var shouldBeAdded = true;
			foreach (var ch in htmlText)
			{
				if (ch.Equals('<'))
					shouldBeAdded = false;
				if (ch.Equals('>'))
					shouldBeAdded = true;
				if (shouldBeAdded && !ch.Equals('>'))
					extractedText += ch.ToString();
			}

        	return extractedText;
        }
    }
}
