        ' Tests for the presence of a CodeNamespace in the collection,
        ' and retrieves its index if it is found.
        Dim testNamespace As New CodeNamespace("TestNamespace")
        Dim itemIndex As Integer = -1
        If collection.Contains(testNamespace) Then
            itemIndex = collection.IndexOf(testNamespace)
        End If