// Gets the attributes for the property.
 AttributeCollection attributes = 
    TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
 
     // Checks to see if the property is bindable.
     BindableAttribute myAttribute = (BindableAttribute)attributes[typeof(BindableAttribute)];
     if(myAttribute.Bindable) 
     {
         // Insert code here.
     }
