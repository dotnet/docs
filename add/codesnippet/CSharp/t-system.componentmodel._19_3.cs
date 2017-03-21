        AttributeCollection attributes = 
            TypeDescriptor.GetAttributes(MyProperty);
         if(attributes[typeof(BrowsableAttribute)].Equals(BrowsableAttribute.Yes)) {
            // Insert code here.
         }