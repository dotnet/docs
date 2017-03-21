    Public Function CreateSessionID(context As HttpContext) As String _
      Implements ISessionIDManager.CreateSessionID
    
      Return Guid.NewGuid().ToString()
    End Function