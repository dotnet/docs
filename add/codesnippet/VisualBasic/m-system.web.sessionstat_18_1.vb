    Public Sub Remove(name As String) Implements IHttpSessionState.Remove    
      pSessionItems.Remove(name)
    End Sub