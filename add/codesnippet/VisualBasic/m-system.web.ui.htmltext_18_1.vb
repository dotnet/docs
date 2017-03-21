            ' Use the Write(string, object) method to
            ' render a formatted string and an object in it.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write("The current cultural settings are {0}.", _
                CultureInfo.CurrentCulture)
            writer.RenderEndTag()