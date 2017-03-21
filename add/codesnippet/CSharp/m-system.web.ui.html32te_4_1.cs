        // Override the RenderBeforeTag method to render the
        // opening tag of a <small> element to modify the text size of 
        // any <a> elements that this writer encounters.
		protected override string RenderBeforeTag()
		{
            // Check whether the element being rendered is an 
            // <a> element. If so, render the opening tag
            // of the <small> element; otherwise, call the base method.
			if (TagKey == HtmlTextWriterTag.A)
				return "<small>";
			return base.RenderBeforeTag();
		}