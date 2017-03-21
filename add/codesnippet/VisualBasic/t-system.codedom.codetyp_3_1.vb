        ' Creates an empty CodeTypeDeclarationCollection.
        Dim collection As New CodeTypeDeclarationCollection()

        ' Adds a CodeTypeDeclaration to the collection.
        collection.Add(New CodeTypeDeclaration("TestType"))

        ' Adds an array of CodeTypeDeclaration objects to the 
        ' collection.
        Dim declarations As CodeTypeDeclaration() = {New CodeTypeDeclaration("TestType1"), New CodeTypeDeclaration("TestType2")}
        collection.AddRange(declarations)

        ' Adds a collection of CodeTypeDeclaration objects to the collection.
        Dim declarationsCollection As New CodeTypeDeclarationCollection()
        declarationsCollection.Add(New CodeTypeDeclaration("TestType1"))
        declarationsCollection.Add(New CodeTypeDeclaration("TestType2"))
        collection.AddRange(declarationsCollection)

        ' Tests for the presence of a CodeTypeDeclaration in the 
        ' collection, and retrieves its index if it is found.
        Dim testDeclaration As New CodeTypeDeclaration("TestType")
        Dim itemIndex As Integer = -1
        If collection.Contains(testDeclaration) Then
            itemIndex = collection.IndexOf(testDeclaration)
        End If

        ' Copies the contents of the collection, beginning at index 0,
        ' to the specified CodeTypeDeclaration array.
        ' 'declarations' is a CodeTypeDeclaration array.
        collection.CopyTo(declarations, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeTypeDeclaration at index 0 of the collection.
        collection.Insert(0, New CodeTypeDeclaration("TestType"))

        ' Removes the specified CodeTypeDeclaration from the collection.
        Dim declaration As New CodeTypeDeclaration("TestType")
        collection.Remove(declaration)

        ' Removes the CodeTypeDeclaration at index 0.
        collection.RemoveAt(0)