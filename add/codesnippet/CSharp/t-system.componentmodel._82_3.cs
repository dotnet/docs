        AttributeCollection attributes = 
           TypeDescriptor.GetAttributes(MyProperty);
        if(attributes[typeof(ReadOnlyAttribute)].Equals(ReadOnlyAttribute.Yes)) {
           // Insert code here.
        }