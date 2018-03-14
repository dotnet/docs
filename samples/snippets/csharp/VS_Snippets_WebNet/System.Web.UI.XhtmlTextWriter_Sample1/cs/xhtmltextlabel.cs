// <snippet1>
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;

namespace AspNet.Samples
{
	// Create a simple class that inherits
    // from the Label class.
	public class TestLabel : Label
	{
		private String _textValue;

		// Override the Text property.
		public override string Text
		{
			get
			{
				return (string)ViewState["Text"];
			}
			set
			{
				ViewState["Text"] = value;
			}
		}
	}
	// <snippet2>
	public class XhtmlTestLabelAdapter : WebControlAdapter
	{
		// Create a control property that accesses the
		// methods and properties of the control.
		protected TestLabel Control
		{
			get
			{
				return (TestLabel)base.Control;
			}
		}

		// <snippet3>
		protected override void Render(HtmlTextWriter writer)
		{
			// Create an instance of the XhtmlTextWriter class,
			// named w, and cast the HtmlTextWriter passed 
			// in the writer parameter to w.
			XhtmlTextWriter w = new XhtmlTextWriter(writer);

			// Create a string variable, named value, to hold
			// the control's Text property value.
			String value = Control.Text;

			
            // Create a Boolean variable, named attTest,
            // to test whether the Style attribute is 
            // valid in the page that the control is
            // rendered to.
            Boolean attTest = w.IsValidFormAttribute("style");

            // Check whether attTest is true or false.
            // If true, a style is applied to the XHTML
            // content. If false, no style is applied.
			if (attTest)
				w.EnterStyle(Control.ControlStyle);

			// Write the Text property value of the control,
            // a <br> element, and a string. Consider encoding the value using WriteEncodedText.
            w.Write(value);
            w.WriteBreak();
            w.Write("This control conditionally rendered its styles for XHTML.");

            // Check whether attTest is true or false.
            // If true, the XHTML style is closed.
            // If false, nothing is rendered.
            if (attTest)
                w.ExitStyle(Control.ControlStyle);
		}
		// </snippet3>

	}
	//</snippet2>

}
// </snippet1>