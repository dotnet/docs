    Public Sub Remove(ByVal key As Object) Implements IDictionary.Remove
        If key = Nothing Then
            Throw New ArgumentNullException("key")
        End If
        ' Try to find the key in the DictionaryEntry array
        Dim index As Integer
        If TryGetIndexOfKey(key, index) Then

            ' If the key is found, slide all the items up.
            Array.Copy(items, index + 1, items, index, (ItemsInUse - index) - 1)
            ItemsInUse = ItemsInUse - 1
        Else

            ' If the key is not in the dictionary, just return. 
        End If
    End Sub