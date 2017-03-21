        // If a <font> element is to be rendered, check whether it contains
        // a size attribute. If it does not, add one and set its value to
        // 20 points, then return true.
        protected override bool OnTagRender(string name, HtmlTextWriterTag key)
        {

            if (key == HtmlTextWriterTag.Font)
            {
                if (!(IsAttributeDefined(HtmlTextWriterAttribute.Size)))
                {
                    AddAttribute(HtmlTextWriterAttribute.Size, "20pt");
                    return true;
                }
            }

            // If the element is not a <font> element, use
            // the base functionality of the OnTagRenderMethod.
            return base.OnTagRender(name, key);
        }