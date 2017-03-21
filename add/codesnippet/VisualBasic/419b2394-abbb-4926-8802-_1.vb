        ' Tests for the presence of a CodeTypeDeclaration in the 
        ' collection, and retrieves its index if it is found.
        Dim testDeclaration As New CodeTypeDeclaration("TestType")
        Dim itemIndex As Integer = -1
        If collection.Contains(testDeclaration) Then
            itemIndex = collection.IndexOf(testDeclaration)
        End If