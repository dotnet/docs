        // Override the OnStyleAttributeRender
        // method to prevent this text writer 
        // from rendering purple text.
        protected override bool OnStyleAttributeRender(string name, 
            string value, 
            HtmlTextWriterStyle key)
        {
            if (key == HtmlTextWriterStyle.Color)
            {
                if (String.Compare(value, "purple") == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return base.OnStyleAttributeRender(name, value, key);
            }        
        }  