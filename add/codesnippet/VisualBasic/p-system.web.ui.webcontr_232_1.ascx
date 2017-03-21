  Public Property Description() As String _
    Implements IWebPart.Description
    Get
      Dim objTitle As Object = ViewState("Description")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("Description") = value
    End Set
  End Property