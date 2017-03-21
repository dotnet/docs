        ' Tests for the presence of a CodeCatchClause in the 
        ' collection, and retrieves its index if it is found.
        Dim testClause As New CodeCatchClause("e")
        Dim itemIndex As Integer = -1
        If collection.Contains(testClause) Then
            itemIndex = collection.IndexOf(testClause)
        End If