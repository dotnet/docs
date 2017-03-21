        // Gets the attributes for the property.
        AttributeCollection attributes = 
           TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
         
        // Checks to see if the value of the RecommendedAsConfigurableAttribute is Yes.
        if(attributes[typeof(RecommendedAsConfigurableAttribute)].Equals(RecommendedAsConfigurableAttribute.Yes)) {
           // Insert code here.
        }
         
        // This is another way to see if the property is recommended as configurable.
        RecommendedAsConfigurableAttribute myAttribute = 
           (RecommendedAsConfigurableAttribute)attributes[typeof(RecommendedAsConfigurableAttribute)];
        if(myAttribute.RecommendedAsConfigurable) {
           // Insert code here.
        }