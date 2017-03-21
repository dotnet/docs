            ' Render a character array as the 
            ' contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write(testChars)
            writer.RenderEndTag()