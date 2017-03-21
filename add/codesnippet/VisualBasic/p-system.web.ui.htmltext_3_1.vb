            ' Get the value of the current markup writer's 
            ' Encoding property, convert it to a string, and 
            ' write it to the HtmlTextWriter stream.
            writer.Write(("Encoding : " + writer.Encoding.ToString() & "<br>"))