        // Gets the attributes for the property.
         AttributeCollection attributes = 
            TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
         
         // Checks to see if the value of the MergablePropertyAttribute is Yes.
         if(attributes[typeof(MergablePropertyAttribute)].Equals(MergablePropertyAttribute.Yes)) {
            // Insert code here.
         }
         
         // This is another way to see if the property is bindable.
         MergablePropertyAttribute myAttribute = 
            (MergablePropertyAttribute)attributes[typeof(MergablePropertyAttribute)];
         if(myAttribute.AllowMerge) {
            // Insert code here.
         }