        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = _
            TypeDescriptor.GetProperties(Me)("MyImage").Attributes
        
        ' Prints the description by retrieving the CategoryAttribute. 
        ' from the AttributeCollection.
        Dim myAttribute As CategoryAttribute = _
            CType(attributes(GetType(CategoryAttribute)), CategoryAttribute)
            Console.WriteLine(myAttribute.Category)