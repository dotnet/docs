    Public Sub RemoveAt(index As Integer) Implements ISessionStateItemCollection.RemoveAt 
      If index < 0 OrElse index >= Me.Count Then _
        Throw New ArgumentOutOfRangeException("The specified index is not within the acceptable range.")
   
      pItems.RemoveAt(index)
      pDirty = True
    End Sub