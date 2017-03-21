    Public ReadOnly Property IsReadOnly As Boolean Implements IHttpSessionState.IsReadOnly    
      Get
        Return pIsReadonly
      End Get
    End Property