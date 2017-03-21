    Public Property Item(ByVal key As Object) As Object Implements IDictionary.Item
        Get

            ' If this key is in the dictionary, return its value.
            Dim index As Integer
            If TryGetIndexOfKey(key, index) Then

                ' The key was found return its value.
                Return items(index).Value
            Else

                ' The key was not found return null.
                Return Nothing
            End If
        End Get

        Set(ByVal value As Object)
            ' If this key is in the dictionary, change its value. 
            Dim index As Integer
            If TryGetIndexOfKey(key, index) Then

                ' The key was found change its value.
                items(index).Value = value
            Else

                ' This key is not in the dictionary add this key/value pair.
                Add(key, value)
            End If
        End Set
    End Property