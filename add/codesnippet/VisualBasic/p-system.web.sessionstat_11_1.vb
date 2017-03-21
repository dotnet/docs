    Public ReadOnly Property Count As Integer Implements IHttpSessionState.Count    
      Get
        Return pSessionItems.Count
      End Get
    End Property