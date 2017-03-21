    Public Sub Clear() Implements IHttpSessionState.Clear 
      pSessionItems.Clear()
    End Sub

    Public Sub RemoveAll() Implements IHttpSessionState.RemoveAll
        Clear()
    End Sub