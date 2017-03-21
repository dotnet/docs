            // Render a formatted string and the
            // text representation of an object array,
            // myObjectArray, as the contents of
            // a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write("The trade value at {1} is ${0}.", curPriceTime);
            writer.RenderEndTag();