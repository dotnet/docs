        // Override the RenderBeforeContent method to write
        // a font element that applies red to the text in a Label element.
        protected override string RenderBeforeContent()
        {
            // Check to determine whether the element being rendered
            // is a label element. If so, render the opening tag
            // of the font element; otherwise, call the base method.
            if (TagKey == HtmlTextWriterTag.Label)
            {
                return "<font color=\"red\">";
            }
            else
            {
                return base.RenderBeforeContent();
            }
        }