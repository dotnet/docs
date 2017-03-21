        ' Adds an array of CodeAttributeDeclaration objects to the collection.
        Dim declarations As CodeAttributeDeclaration() = {New CodeAttributeDeclaration(), New CodeAttributeDeclaration()}
        collection.AddRange(declarations)

        ' Adds a collection of CodeAttributeDeclaration objects to 
        ' the collection.
        Dim declarationsCollection As New CodeAttributeDeclarationCollection()
        declarationsCollection.Add(New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description"))))
        declarationsCollection.Add(New CodeAttributeDeclaration("BrowsableAttribute", New CodeAttributeArgument(New CodePrimitiveExpression(True))))
        collection.AddRange(declarationsCollection)