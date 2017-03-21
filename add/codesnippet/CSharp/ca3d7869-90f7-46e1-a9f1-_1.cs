            // If the <label> element is rendered and a style
            // attribute is not defined, add a style attribute 
            // and set its value to blue.
            if (TagKey == HtmlTextWriterTag.Label)
            {
                if (!IsAttributeDefined(HtmlTextWriterAttribute.Style))
                {
                    AddAttribute("style", EncodeAttributeValue("color:blue", true));
                    Write(NewLine);
                    Indent = 3;
                    OutputTabs();
                }
            }