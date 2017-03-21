  Public Property CatalogIconImageUrl() As String _
    Implements IWebPart.CatalogIconImageUrl
    Get
      Dim objTitle As Object = ViewState("CatalogIconImageUrl")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("CatalogIconImageUrl") = value
    End Set
  End Property