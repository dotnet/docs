	// Create a custom CHTML Adapter for a 
	// SimpleLabel class.
	public class ChtmlSimpleLabelAdapter : WebControlAdapter
	{
		// Create the Control property to access
		// the properties and methods of the
		// SimpleLabel class.
		protected SimpleLabel Control
		{
			get
			{
				return (SimpleLabel)base.Control;
			}
		}

		// Override the Render method to render text
		// in CHTML with the style defined by the control
		// and a <br> element after the text and styles
		// have been written to the output stream. 
		protected override void Render(HtmlTextWriter writer)
		{
			ChtmlTextWriter w = new ChtmlTextWriter(writer);
			string value = Control.Text;

			// Render the text of the control using
			// the control's style settings.
			w.EnterStyle(Control.ControlStyle);
			w.Write(value);
			w.ExitStyle(Control.ControlStyle);
			w.WriteBreak();
		}
	}