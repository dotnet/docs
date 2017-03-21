    Public Property Item(name As String) As Object Implements IHttpSessionState.Item
      Get
        Return pSessionItems(name)
      End Get
      Set
        pSessionItems(name) = value
      End Set
    End Property