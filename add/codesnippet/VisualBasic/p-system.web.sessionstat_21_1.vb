    Public ReadOnly Property Keys As NameObjectCollectionBase.KeysCollection _
      Implements ISessionStateItemCollection.Keys
      Get
        Return CType(pItems.Keys, NameObjectCollectionBase.KeysCollection)
      End Get
    End Property