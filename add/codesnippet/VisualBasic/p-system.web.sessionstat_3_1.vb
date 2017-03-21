    Public Property Item(index As Integer) As Object Implements ISessionStateItemCollection.Item
      Get
        Return pItems(index)
      End Get
      Set
        pItems(index) = value
        pDirty = True
      End Set
    End Property