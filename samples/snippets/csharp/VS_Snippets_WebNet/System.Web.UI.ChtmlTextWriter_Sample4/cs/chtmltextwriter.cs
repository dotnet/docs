// <Snippet1>
// Create a class that derives from the
// ChtmlTextWriter class.
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls.Adapters;

namespace AspNet.Samples.CS
{
	public class CustomChtmlTextWriter : ChtmlTextWriter
	{
		// Create two constructors for the new
		// text writer.
		public CustomChtmlTextWriter(TextWriter writer) : base(writer, DefaultTabString)
		{
		}

		public CustomChtmlTextWriter(TextWriter writer, String tabString)
			: base(writer, tabString)
		{
		}
		
		// <Snippet2>
		// Override the OnAttributeRender method to
		// not render the bgcolor attribute, which is
		// not supported in CHTML.
		protected override bool OnAttributeRender(string name, string value, HtmlTextWriterAttribute key)
		{
			if (String.Equals("bgcolor", name))
			{
				return false;
			}
			
			// Call the ChtmlTextWriter version of the
			// the OnAttributeRender method.
			return base.OnAttributeRender(name, value, key);
		}
		// </Snippet2>
	}

	// <Snippet3>
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
	// </Snippet3>
}
// </Snippet1>