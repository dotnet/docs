            // Write the name of the image file from the 
            // FileName property, close the path, and then
            // close the <img> element.
            writer.Write(FileName);
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
            writer.Write(HtmlTextWriter.SelfClosingTagEnd);