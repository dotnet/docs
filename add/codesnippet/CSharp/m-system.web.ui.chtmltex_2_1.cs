	// Derive from the WebControlAdapter class,
	// provide a CreateCustomChtmlTextWriter
	// method to attach to the custom writer.
	public class ChtmlCustomPageAdapter : WebControlAdapter
	{
		protected internal ChtmlTextWriter CreateCustomChtmlTextWriter(
			TextWriter writer)
		{
			return new CustomChtmlTextWriter(writer);
		}
	}