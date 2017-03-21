        // Gets the attributes for the property.
        AttributeCollection attributes = 
           TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
         
        // Checks to see whether the value of the ReadOnlyAttribute is Yes.
        if(attributes[typeof(ReadOnlyAttribute)].Equals(ReadOnlyAttribute.Yes)) {
           // Insert code here.
        }
         
        // This is another way to see whether the property is read-only.
        ReadOnlyAttribute myAttribute = 
           (ReadOnlyAttribute)attributes[typeof(ReadOnlyAttribute)];
        if(myAttribute.IsReadOnly) {
           // Insert code here.
        }