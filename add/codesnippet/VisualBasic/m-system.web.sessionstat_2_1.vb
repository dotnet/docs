    Public Sub Clear() Implements ISessionStateItemCollection.Clear
      pItems.Clear()
      pDirty = True
    End Sub