        ' Removes the specified CodeAttributeDeclaration from the collection.
        Dim declaration As New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description")))
        collection.Remove(declaration)