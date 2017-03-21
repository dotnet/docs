            // Render a subarray of a character array
            // as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write(testChars, 0, 5);
            writer.RenderEndTag();