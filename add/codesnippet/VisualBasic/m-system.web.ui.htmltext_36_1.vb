            ' Control the encoding of attributes.
            ' Simple known values do not need encoding.
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, "Encoding, ""Required""", True)
            writer.AddAttribute("myattribute", "No &quot;encoding &quot; required", False)
            writer.RenderBeginTag(HtmlTextWriterTag.Img)
            writer.RenderEndTag()
            writer.WriteLine()