  Public Sub Page_PreInit(ByVal Sender As Object, ByVal e As EventArgs)
        
    ' Get the theme name from a QueryString variable
    Dim ThemeName As String
    ThemeName = Request.QueryString("thename")
    If ThemeName <> Nothing Then
      Page.Theme = ThemeName
    End If
  End Sub