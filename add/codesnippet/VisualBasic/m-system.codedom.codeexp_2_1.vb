        ' Tests for the presence of a CodeExpression in the 
        ' collection, and retrieves its index if it is found.
        Dim testComment = New CodePrimitiveExpression(True)
        Dim itemIndex As Integer = -1
        If collection.Contains(testComment) Then
            itemIndex = collection.IndexOf(testComment)
        End If