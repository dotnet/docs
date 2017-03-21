    Public Sub AddItemToCache(sender As Object, e As EventArgs)
        itemRemoved = false

        onRemove = New CacheItemRemovedCallback(AddressOf Me.RemovedCallback)

        If (IsNothing(Cache("Key1"))) Then
          Cache.Add("Key1", "Value 1", Nothing, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove)
        End If
    End Sub