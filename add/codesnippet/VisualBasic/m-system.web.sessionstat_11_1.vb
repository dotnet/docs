    Public Sub CopyTo(items As Array, index As Integer) Implements IHttpSessionState.CopyTo    
      For Each o As Object In items
        items.SetValue(o, index)
        index += 1
      Next
    End Sub