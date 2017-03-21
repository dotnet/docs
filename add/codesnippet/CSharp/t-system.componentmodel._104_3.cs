            AttributeCollection attributes = 
                TypeDescriptor.GetAttributes(MyProperty);
             if(attributes[typeof(MergablePropertyAttribute)].Equals(MergablePropertyAttribute.Yes)) {
                // Insert code here.
             }