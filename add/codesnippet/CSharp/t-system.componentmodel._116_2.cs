    // Gets the attributes for the property.
     AttributeCollection attributes = 
        TypeDescriptor.GetProperties(this)["MyImage"].Attributes;
     
     /* Prints the description by retrieving the DescriptionAttribute 
      * from the AttributeCollection. */
     DescriptionAttribute myAttribute = 
        (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];
     Console.WriteLine(myAttribute.Description);