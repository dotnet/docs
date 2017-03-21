        // Shadow the control properties with design-time properties.
        protected override void PreFilterProperties(IDictionary properties)
        {
            // Call the base method first.
            base.PreFilterProperties(properties);

            // Make the NamingContainer visible in the Properties grid.
            PropertyDescriptor selectProp = 
                (PropertyDescriptor)properties["NamingContainer"];
            properties["NamingContainer"] =
                TypeDescriptor.CreateProperty(selectProp.ComponentType, 
                    selectProp, BrowsableAttribute.Yes);
        } // PreFilterProperties