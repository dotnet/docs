    Private pDirty As Boolean = False

    Public Property Dirty As Boolean Implements ISessionStateItemCollection.Dirty    
      Get
        Return pDirty
      End Get
      Set
        pDirty = value
      End Set
    End Property