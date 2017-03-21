    Public Sub Remove(name As String) Implements ISessionStateItemCollection.Remove
      pItems.Remove(name)
      pDirty = True
    End Sub