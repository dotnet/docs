    // Gets the attributes for the property.
     AttributeCollection attributes = 
        TypeDescriptor.GetProperties(this)["MyImage"].Attributes;
     
     // Prints the description by retrieving the CategoryAttribute.
     // from the AttributeCollection.
     CategoryAttribute myAttribute = 
        (CategoryAttribute)attributes[typeof(CategoryAttribute)];
     Console.WriteLine(myAttribute.Category);