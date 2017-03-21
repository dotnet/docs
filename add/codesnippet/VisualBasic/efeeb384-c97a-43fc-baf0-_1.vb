            ' Use the WriteLine(string,object,object) method to
            ' render a formatted string and two objects 
            ' in the string.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine("The current cultural settings are {0}. Today's date is {1}.", _
                CultureInfo.CurrentCulture, DateTime.Today)
            writer.RenderEndTag()