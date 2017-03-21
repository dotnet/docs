        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = _
            TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Prints the default value by retrieving the DefaultValueAttribute
        ' from the AttributeCollection. 
        Dim myAttribute As DefaultValueAttribute = _
            CType(attributes(GetType(DefaultValueAttribute)), DefaultValueAttribute)
        Console.WriteLine(("The default value is: " & myAttribute.Value.ToString()))