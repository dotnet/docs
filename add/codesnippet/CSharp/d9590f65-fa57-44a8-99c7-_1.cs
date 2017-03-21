        // If a color style attribute is to be rendered,
        // compare its value to purple. If it is not set to
        // purple, add the style attribute and set the value
        // to purple, then return false.
        protected override bool OnStyleAttributeRender(string name,
            string value,
            HtmlTextWriterStyle key)
        {

            if (key == HtmlTextWriterStyle.Color)
            {
                if (string.Compare(value, "purple") != 0)
                {
                    AddStyleAttribute("color", "purple");
                    return false;
                }
            }

            // If the style attribute is not a color attribute,
            // use the base functionality of the
            // OnStyleAttributeRender method.
            return base.OnStyleAttributeRender(name, value, key);
        }