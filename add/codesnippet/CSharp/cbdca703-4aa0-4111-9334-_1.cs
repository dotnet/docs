            // If the tagKey parameter is set to a <font> element
            // but a size attribute is not defined on the element,
            // the AddStyleAttribute method adds a size attribute
            // and sets it to 30 point. 
            if (tagKey == HtmlTextWriterTag.Font)
            {
                if (!IsAttributeDefined(HtmlTextWriterAttribute.Size))
                {
                    AddAttribute(GetAttributeKey("size"), "30pt");
                }
            }