    Public ReadOnly Property Keys As NameObjectCollectionBase.KeysCollection _
      Implements IHttpSessionState.Keys
    
      Get
        Return pSessionItems.Keys
      End Get
    End Property