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