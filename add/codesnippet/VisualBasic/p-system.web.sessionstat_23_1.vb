    Public Property Item(index As Integer) As Object Implements IHttpSessionState.Item    
      Get
        Return pSessionItems(index)
      End Get
      Set
        pSessionItems(index) = value
      End Set
    End Property