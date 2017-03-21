		// Override the RenderAfterContent method to close
		// styles opened during the call to the RenderBeforeContent
		// method.
		protected override string RenderAfterContent()
		{
			// Check whether the element being rendered is a <th> element.
			// If so, and the requesting device supports bold formatting,
			// render the closing tag of the <b> element. If not,
			// render the closing tag of the <font> element.
			if (TagKey == HtmlTextWriterTag.Th)
			{
				if (SupportsBold)
					return "</b>";
				else
					return "</font>";
			}

			// Check whether the element being rendered is an <H4>.
            // element. If so, and the requesting device supports italic
            // formatting, render the closing tag of the <i> element.
            // If not, render the closing tag of the <font> element.
			if (TagKey == HtmlTextWriterTag.H4)
			{
				if (SupportsItalic)
					return "</i>";
				else
					return "</font>";
			}
			// Call the base method
			return base.RenderAfterContent();
		}