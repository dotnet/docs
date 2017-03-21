        ' Tests for the presence of a CodeAttributeArgument in 
        ' the collection, and retrieves its index if it is found.
        Dim testArgument As New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True))
        Dim itemIndex As Integer = -1
        If collection.Contains(testArgument) Then
            itemIndex = collection.IndexOf(testArgument)
        End If