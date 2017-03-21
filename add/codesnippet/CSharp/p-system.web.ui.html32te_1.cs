		// Override the RenderBeforeContent method to render
		// styles before rendering the content of a <th> element.
		protected override string RenderBeforeContent()
		{
			// Check the TagKey property. If its value is
			// HtmlTextWriterTag.TH, check the value of the 
			// SupportsBold property. If true, return the
			// opening tag of a <b> element; otherwise, render
			// the opening tag of a <font> element with a color
			// attribute set to the hexadecimal value for red.
			if (TagKey == HtmlTextWriterTag.Th)
			{
				if (SupportsBold)
					return "<b>";
				else
					return "<font color=\"FF0000\">";
			}

			// Check whether the element being rendered
            // is an <H4> element. If it is, check the 
            // value of the SupportsItalic property.
            // If true, render the opening tag of the <i> element
            // prior to the <H4> element's content; otherwise, 
            // render the opening tag of a <font> element 
            // with a color attribute set to the hexadecimal
            // value for navy blue.
			if (TagKey == HtmlTextWriterTag.H4)
			{
				if (SupportsItalic)
					return "<i>";
				else
					return "<font color=\"000080\">";
			}
			// Call the base method.
			return base.RenderBeforeContent();
		}