            ' Create a non-standard tag.
            writer.RenderBeginTag("MyTag")
            writer.Write("Contents of MyTag")
            writer.RenderEndTag()
            writer.WriteLine()