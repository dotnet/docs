        ' Tests for the presence of a CodeTypeReference in the 
        ' collection, and retrieves its index if it is found.
        Dim testReference As New CodeTypeReference(GetType(Boolean))
        Dim itemIndex As Integer = -1
        If collection.Contains(testReference) Then
            itemIndex = collection.IndexOf(testReference)
        End If