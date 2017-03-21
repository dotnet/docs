        ' Tests for the presence of a CodeAttributeDeclaration in the 
        ' collection, and retrieves its index if it is found.
        Dim testdeclaration As New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description")))
        Dim itemIndex As Integer = -1
        If collection.Contains(testdeclaration) Then
            itemIndex = collection.IndexOf(testdeclaration)
        End If