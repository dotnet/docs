        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = _
            TypeDescriptor.GetProperties(Me)("MyImage").Attributes
        
        ' Prints the description by retrieving the DescriptionAttribute
        ' from the AttributeCollection. 
        Dim myAttribute As DescriptionAttribute = _
            CType(attributes(GetType(DescriptionAttribute)), DescriptionAttribute)
        Console.WriteLine(myAttribute.Description)