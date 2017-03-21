        // Shadow the control properties with design-time properties.
        protected override void PreFilterProperties(IDictionary properties)
        {
            string namingContainer = "NamingContainer";

            // Call the base method first.
            base.PreFilterProperties(properties);

            // Make the NamingContainery visible in the Properties grid.
            PropertyDescriptor selectProp =
                (PropertyDescriptor)properties[namingContainer];
            properties[namingContainer] =
                TypeDescriptor.CreateProperty(selectProp.ComponentType,
                    selectProp, BrowsableAttribute.Yes);
        } // PreFilterProperties