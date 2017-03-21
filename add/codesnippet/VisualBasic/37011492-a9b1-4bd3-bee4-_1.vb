    Public Function Contains(ByVal key As Object) As Boolean Implements IDictionary.Contains
        Dim index As Integer
        Return TryGetIndexOfKey(key, index)
    End Function