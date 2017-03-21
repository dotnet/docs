        AttributeCollection attributes = 
            TypeDescriptor.GetAttributes(MyProperty);
         if(attributes[typeof(BindableAttribute)].Equals(BindableAttribute.Yes)) {
            // Insert code here.
         }