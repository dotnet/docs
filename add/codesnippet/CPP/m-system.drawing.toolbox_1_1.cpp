private:
    static Image^ GetImageOfCustomControl(Control^ userControl)
    {
        Image^ controlImage = nullptr;
        AttributeCollection^ attrCol =
            TypeDescriptor::GetAttributes(userControl);
        ToolboxBitmapAttribute^ imageAttr = (ToolboxBitmapAttribute^)
            attrCol[ToolboxBitmapAttribute::typeid];
        if (imageAttr != nullptr)
        {
            controlImage = imageAttr->GetImage(userControl);
        }

        return controlImage;
    }