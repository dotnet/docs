            // If the markup element being rendered is a Label,
            // render the opening tag of a Font element before it.
            if (tagKey == HtmlTextWriterTag.Label)
            {
                // Check whether a Color style attribute is 
                // included on the Label. If not, use the
                // AddStyleAttribute and GetStyleName methods to add one
                // and set its value to red.
                if (!IsStyleAttributeDefined(HtmlTextWriterStyle.Color))
                {
                    AddStyleAttribute(GetStyleName(HtmlTextWriterStyle.Color), "red");
                }