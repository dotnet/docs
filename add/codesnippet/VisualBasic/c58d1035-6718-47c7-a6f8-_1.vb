        ' Tests for the presence of a CodeCommentStatement in the 
        ' collection, and retrieves its index if it is found.
        Dim testComment As New CodeCommentStatement("Test comment")
        Dim itemIndex As Integer = -1
        If collection.Contains(testComment) Then
            itemIndex = collection.IndexOf(testComment)
        End If