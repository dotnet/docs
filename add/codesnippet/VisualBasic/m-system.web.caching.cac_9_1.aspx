    Public Sub RemoveItemFromCache(sender As Object, e As EventArgs)
        If (Not IsNothing(Cache("Key1"))) Then
          Cache.Remove("Key1")
        End If
    End Sub