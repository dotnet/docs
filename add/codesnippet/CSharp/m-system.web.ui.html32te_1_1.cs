        // Override the RenderAfterTag method to render
        // close any elements opened in the RenderBeforeTag
        // method call.
		protected override string RenderAfterTag()
		{
            // Check whether the element being rendered is an
            // <a> element. If so, render the closing tag of the
            // <small> element; otherwise, call the base method.
			if (TagKey == HtmlTextWriterTag.A)
				return "</small>";
			return base.RenderAfterTag();
		}