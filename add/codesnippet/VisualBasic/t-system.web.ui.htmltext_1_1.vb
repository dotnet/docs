        ' Overrides the Render method to write a <span> element
        ' that applies styles and attributes.     
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

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

            writer.Write("Hello")
            writer.WriteLine()

            ' Controls the encoding of markup attributes
            ' for an <img> element. Simple known values 
            ' do not need encoding.
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, _
                "Encoding, ""Required""", _
                True)
            writer.AddAttribute("myattribute", _
                "No &quot;encoding &quot; required", _
                False)
            writer.RenderBeginTag(HtmlTextWriterTag.Img)
            writer.RenderEndTag()
            writer.WriteLine()

            ' Create a non-standard markup element.
            writer.RenderBeginTag("Mytag")
            writer.Write("Contents of MyTag")
            writer.RenderEndTag()
            writer.WriteLine()

            ' Create a manually rendered <img> element
            ' that contains an alt attribute.
            writer.WriteBeginTag("img")
            writer.WriteAttribute("alt", "A custom image.")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("img")

            writer.WriteLine()

            writer.Indent -= 1
            writer.RenderEndTag()

        End Sub 'Render