        AttributeCollection attributes = 
           TypeDescriptor.GetAttributes(MyProperty);
        if(attributes[typeof(RecommendedAsConfigurableAttribute)].Equals(RecommendedAsConfigurableAttribute.Yes)) {
           // Insert code here.
        }