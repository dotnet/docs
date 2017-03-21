    Public Sub Add(name As String, value As Object) Implements IHttpSessionState.Add    
      pSessionItems(name) = value        
    End Sub