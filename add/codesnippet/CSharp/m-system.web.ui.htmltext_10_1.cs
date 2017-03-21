             // Use the Write(Double) method to render
             // the MaxValue field of the Double structure. 
             writer.RenderBeginTag(HtmlTextWriterTag.Label);
             writer.Write(Double.MaxValue);
             writer.RenderEndTag();