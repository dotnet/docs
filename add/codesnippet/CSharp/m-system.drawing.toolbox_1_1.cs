        private Image GetImageOfCustomControl(Control userControl)
        {
            Image controlImage = null;
            AttributeCollection attrCol = 
                    TypeDescriptor.GetAttributes(userControl);
            ToolboxBitmapAttribute imageAttr = (ToolboxBitmapAttribute)
                attrCol[typeof(ToolboxBitmapAttribute)];
            if (imageAttr != null)
            {
                controlImage = imageAttr.GetImage(userControl);
            }

            return controlImage;
        }