    // Gets the attributes for the property.
     AttributeCollection attributes = 
        TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
     
     /* Prints the default value by retrieving the DefaultValueAttribute 
      * from the AttributeCollection. */
     DefaultValueAttribute myAttribute = 
        (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
     Console.WriteLine("The default value is: " + myAttribute.Value.ToString());