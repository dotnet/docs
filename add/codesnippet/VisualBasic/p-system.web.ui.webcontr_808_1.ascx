  Public Property Title() As String _
    Implements IWebPart.Title
    Get
      Dim objTitle As Object = ViewState("Title")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("Title") = value
    End Set
  End Property