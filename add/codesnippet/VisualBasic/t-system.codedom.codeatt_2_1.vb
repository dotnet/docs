        ' Creates an empty CodeAttributeDeclarationCollection.
        Dim collection As New CodeAttributeDeclarationCollection()

        ' Adds a CodeAttributeDeclaration to the collection.
        collection.Add(New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description"))))

        ' Adds an array of CodeAttributeDeclaration objects to the collection.
        Dim declarations As CodeAttributeDeclaration() = {New CodeAttributeDeclaration(), New CodeAttributeDeclaration()}
        collection.AddRange(declarations)

        ' Adds a collection of CodeAttributeDeclaration objects to 
        ' the collection.
        Dim declarationsCollection As New CodeAttributeDeclarationCollection()
        declarationsCollection.Add(New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description"))))
        declarationsCollection.Add(New CodeAttributeDeclaration("BrowsableAttribute", New CodeAttributeArgument(New CodePrimitiveExpression(True))))
        collection.AddRange(declarationsCollection)

        ' Tests for the presence of a CodeAttributeDeclaration in the 
        ' collection, and retrieves its index if it is found.
        Dim testdeclaration As New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description")))
        Dim itemIndex As Integer = -1
        If collection.Contains(testdeclaration) Then
            itemIndex = collection.IndexOf(testdeclaration)
        End If

        ' Copies the contents of the collection beginning at index 0 to the specified CodeAttributeDeclaration array.
        ' 'declarations' is a CodeAttributeDeclaration array.
        collection.CopyTo(declarations, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeAttributeDeclaration at index 0 of the collection.
        collection.Insert(0, New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description"))))

        ' Removes the specified CodeAttributeDeclaration from the collection.
        Dim declaration As New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description")))
        collection.Remove(declaration)

        ' Removes the CodeAttributeDeclaration at index 0.
        collection.RemoveAt(0)