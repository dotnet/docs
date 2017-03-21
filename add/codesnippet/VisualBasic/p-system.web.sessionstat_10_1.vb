    Public ReadOnly Property IsNewSession As Boolean Implements IHttpSessionState.IsNewSession
      Get
        Return pNewSession
      End Get
    End Property