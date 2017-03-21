            ' Use the WriteLine(string, object) method to
            ' render a formatted string and an object in it.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine("The current cultural settings are {0}.", _
                CultureInfo.CurrentCulture)
            writer.RenderEndTag()