        // Adds a property to this designer's control at design time 
        // that indicates the outline color to use. 
        // The DesignOnlyAttribute ensures that the OutlineColor
        // property is not serialized by the designer.
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            PropertyDescriptor pd = TypeDescriptor.CreateProperty(
                typeof(ExampleControlDesigner), 
                "OutlineColor",
                typeof(System.Drawing.Color),
                new Attribute[] { new DesignOnlyAttribute(true) });

            properties.Add("OutlineColor", pd);
        }