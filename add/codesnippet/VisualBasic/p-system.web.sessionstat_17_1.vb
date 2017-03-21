    Public ReadOnly Property StaticObjects As HttpStaticObjectsCollection _
      Implements IHttpSessionState.StaticObjects
    
      Get
        Return pStaticObjects
      End Get
    End Property