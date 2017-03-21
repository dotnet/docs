             // Use the Write(string,object,object) method to
             // render a formatted string and two objects 
             // in the string.
             writer.RenderBeginTag(HtmlTextWriterTag.Label);
             writer.Write("The current cultural settings are {0}. Today's date is {1}.",
                 CultureInfo.CurrentCulture, DateTime.Today);
             writer.RenderEndTag();