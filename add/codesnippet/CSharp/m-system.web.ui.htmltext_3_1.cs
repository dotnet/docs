             // Use the WriteLine method to render an arbitrary
             // object, in this case a CutltureInfo object.
             writer.RenderBeginTag(HtmlTextWriterTag.B);
             writer.WriteLine(CultureInfo.CurrentCulture);
             writer.RenderEndTag();