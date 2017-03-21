             // Use the WriteLine(Double) method to render
             // the MaxValue field of the Double structure. 
             writer.RenderBeginTag(HtmlTextWriterTag.Label);
             writer.WriteLine(Double.MaxValue);
             writer.RenderEndTag();