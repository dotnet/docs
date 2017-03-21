            ' Set attributes and values along with attributes and styles
            ' attribute defined for a <span> element.
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "alert('Hello');")
            writer.AddAttribute("CustomAttribute", "CustomAttributeValue")
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Red")
            writer.AddStyleAttribute("CustomStyle", "CustomStyleValue")
            writer.RenderBeginTag(HtmlTextWriterTag.Span)

            '  Create a space and indent the markup inside the 
            ' <span> element.
            writer.WriteLine()
            writer.Indent += 1