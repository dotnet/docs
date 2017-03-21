    Shared itemRemoved As boolean = false
    Shared reason As CacheItemRemovedReason
    Dim onRemove As CacheItemRemovedCallback

    Public Sub RemovedCallback(k As String, v As Object, r As CacheItemRemovedReason)
      itemRemoved = true
      reason = r
    End Sub