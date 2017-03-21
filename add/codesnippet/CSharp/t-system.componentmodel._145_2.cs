        // Gets the attributes for the property.
         AttributeCollection attributes = 
            TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
         
         // Checks to see if the value of the BindableAttribute is Yes.
         if(attributes[typeof(BindableAttribute)].Equals(BindableAttribute.Yes)) {
            // Insert code here.
         }
         
         // This is another way to see whether the property is bindable.
         BindableAttribute myAttribute = 
            (BindableAttribute)attributes[typeof(BindableAttribute)];
         if(myAttribute.Bindable) {
            // Insert code here.
         }

	 // Yet another way to see whether the property is bindable.
	 if (attributes.Contains(BindableAttribute.Yes)) {
	    // Insert code here.
	 }
