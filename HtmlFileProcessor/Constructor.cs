namespace HtmlFileProcessor
{
	public class Constructor
	{
		public string Name { get; private set; }
		public string Description { get; private set; }

		public Constructor(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Constructor))
				return false;

			var ctor = (Constructor)obj;
			return Name.Equals(ctor.Name) && Description.Equals(ctor.Description);
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", Name, Description);
		}
	}
}
