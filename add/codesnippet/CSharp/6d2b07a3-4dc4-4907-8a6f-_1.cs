        // Override the OnAttributeRender method to 
        // allow this text writer to render only eight-point 
        // text size.
        protected override bool OnAttributeRender(string name, 
          string value, 
          HtmlTextWriterAttribute key) 
        {
            if (key == HtmlTextWriterAttribute.Size)
            {
                if (String.Compare(value, "8pt") == 0)
                {
                    return true;
                }
                else
                {
                   return false;
                } 
             }
             else
             {
                 return base.OnAttributeRender(name, value, key);
             }

         }