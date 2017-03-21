  ReadOnly Property Subtitle() As String _
    Implements IWebPart.Subtitle
    Get
      Dim objSubTitle As Object = ViewState("Subtitle")
      If objSubTitle Is Nothing Then
        Return "My Subtitle"
      End If
      Return CStr(objSubTitle)
    End Get
  End Property