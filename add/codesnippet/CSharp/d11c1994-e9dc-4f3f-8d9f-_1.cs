        // Shadow the control properties with design-time properties.
        protected override void PreFilterProperties(IDictionary properties)
        {
            // Call the base method first.
            base.PreFilterProperties(properties);

            // Make the Page visible in the Properties grid.
            PropertyDescriptor selectProp = 
                (PropertyDescriptor)properties["Page"];
            properties["Page"] =
                TypeDescriptor.CreateProperty(selectProp.ComponentType, 
                    selectProp, BrowsableAttribute.Yes);
        } // PreFilterProperties