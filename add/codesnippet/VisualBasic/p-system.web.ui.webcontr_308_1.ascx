  Public Property TitleIconImageUrl() As String _
    Implements IWebPart.TitleIconImageUrl
    Get
      Dim objTitle As Object = ViewState("TitleIconImageUrl")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("TitleIconImageUrl") = value
    End Set
  End Property