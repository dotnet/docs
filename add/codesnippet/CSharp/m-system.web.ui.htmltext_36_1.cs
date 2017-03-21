            // Control the encoding of attributes. 
            // Simple known values do not need encoding.
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, "Encoding, \"Required\"", true);
            writer.AddAttribute("myattribute", "No &quot;encoding &quot; required", false);
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();
            writer.WriteLine();