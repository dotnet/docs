            ' Write a space and a FontWeight
            ' attribute to the tag.
            writer.Write(HtmlTextWriter.SpaceChar)
            writer.Write("FontWeight")

            ' Set the FontWeight attribute to Bold.
            writer.Write(HtmlTextWriter.StyleEqualsChar)
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
            writer.Write("bold")
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
