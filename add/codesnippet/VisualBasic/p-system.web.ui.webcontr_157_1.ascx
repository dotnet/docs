  Public Property TitleUrl() As String _
    Implements IWebPart.TitleUrl
    Get
      Dim objTitle As Object = ViewState("TitleUrl")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("TitleUrl") = value
    End Set
  End Property