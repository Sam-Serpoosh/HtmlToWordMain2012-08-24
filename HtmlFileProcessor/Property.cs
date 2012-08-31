namespace HtmlFileProcessor
{
	public class Property
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public bool IsPublic { get; private set; }

		public Property(string name, string description, bool isPublic)
		{
			Name = name;
			Description = description;
			IsPublic = isPublic;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Property))
				return false;

			var prop = (Property)obj;
			return Name.Equals(prop.Name) && Description.Equals(prop.Description) && 
				IsPublic.Equals(prop.IsPublic);
		}
	}
}
