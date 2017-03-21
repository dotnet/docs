    Public Property Item(name As String) As Object Implements ISessionStateItemCollection.Item
      Get
        Return pItems(name)
      End Get
      Set
        pItems(name) = value
        pDirty = True
      End Set
    End Property