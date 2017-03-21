 // Gets the attributes for the property.
 AttributeCollection attributes = 
    TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
 
 // Checks to see whether the property is read-only.
 ReadOnlyAttribute myAttribute = 
    (ReadOnlyAttribute)attributes[typeof(ReadOnlyAttribute)];
 
 if(myAttribute.IsReadOnly) {
    // Insert code here.
 }
 