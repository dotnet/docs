        ' Tests for the presence of a CodeStatement in the 
        ' collection, and retrieves its index if it is found.
        Dim itemIndex As Integer = -1
        If collection.Contains(testStatement) Then
            itemIndex = collection.IndexOf(testStatement)
        End If