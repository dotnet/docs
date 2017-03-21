    Public Sub Add(ByVal key As Object, ByVal value As Object) Implements IDictionary.Add

        ' Add the new key/value pair even if this key already exists in the dictionary.
        If ItemsInUse = items.Length Then
            Throw New InvalidOperationException("The dictionary cannot hold any more items.")
        End If
        items(ItemsInUse) = New DictionaryEntry(key, value)
        ItemsInUse = ItemsInUse + 1
    End Sub