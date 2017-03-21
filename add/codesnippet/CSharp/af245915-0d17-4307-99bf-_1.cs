        // Returns the properties of the specified component extended with 
        // a CategoryAttribute reflecting the name of the type of the property.
        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(object component, System.Attribute[] attributes)
        {
            PropertyDescriptorCollection props;
            if( attributes == null )
                props = TypeDescriptor.GetProperties(component);    
            else
                props = TypeDescriptor.GetProperties(component, attributes);    
            
            PropertyDescriptor[] propArray = new PropertyDescriptor[props.Count];            
            for(int i=0; i<props.Count; i++)           
            {                
                // Create a new PropertyDescriptor from the old one, with 
                // a CategoryAttribute matching the name of the type.
                propArray[i] = TypeDescriptor.CreateProperty(props[i].ComponentType, props[i], new CategoryAttribute(props[i].PropertyType.Name));
            }
            return new PropertyDescriptorCollection( propArray );
        }

        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(object component)
        {                     
            return this.GetProperties(component, null);
        }