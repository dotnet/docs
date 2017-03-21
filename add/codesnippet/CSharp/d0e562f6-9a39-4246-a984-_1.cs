        // If a size attribute is to be rendered, compare its value to 30 point.
        // If it is not set to 30 point, add the attribute and set the value to 30,
        // then return false.
        protected override bool OnAttributeRender(string name,
            string value,
            HtmlTextWriterAttribute key)
        {

            if (key == HtmlTextWriterAttribute.Size)
            {
                if (string.Compare(value, "30pt") != 0)
                {
                    AddAttribute("size", "30pt");
                    return false;
                }
            }

            // If the attribute is not a size attribute, use
            // the base functionality of the OnAttributeRender method.
            return base.OnAttributeRender(name, value, key);
        }