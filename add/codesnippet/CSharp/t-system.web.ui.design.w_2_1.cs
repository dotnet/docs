        // Shadow control properties with design time properties.
        protected override void PreFilterProperties(IDictionary properties)
        {
            // Call the base class method first.
            base.PreFilterProperties(properties);

            // Add the ConnectionString property to the property grid.
            PropertyDescriptor property =
                (PropertyDescriptor)properties["ConnectionString"];
            Attribute[] attributes = new Attribute[]
            {
                new BrowsableAttribute(true),
                new ReadOnlyAttribute(true)
            };
            properties["ConnectionString"] = TypeDescriptor.CreateProperty(
                GetType(), property, attributes);
        }