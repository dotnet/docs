 // Gets the attributes for the property.
 AttributeCollection attributes = 
    TypeDescriptor.GetProperties(this)["MyPropertyProperty"].Attributes;
 
 // Checks to see if the property is bindable.
 MergablePropertyAttribute myAttribute = (MergablePropertyAttribute)attributes[typeof(MergablePropertyAttribute)];
 if(myAttribute.AllowMerge) {
    // Insert code here.
 }
 