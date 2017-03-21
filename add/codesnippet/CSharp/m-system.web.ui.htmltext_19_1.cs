             // Use the Write method to render an arbitrary
             // object, in this case a CultureInfo object. 
             writer.Write("This is a rendered CultureInfo Object.");
             writer.RenderBeginTag(HtmlTextWriterTag.B);
             writer.Write(CultureInfo.CurrentCulture);
             writer.RenderEndTag();