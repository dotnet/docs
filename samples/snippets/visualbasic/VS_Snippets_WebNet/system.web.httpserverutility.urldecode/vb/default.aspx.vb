' <snippet1>
Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim returnUrl = Server.UrlDecode(Request.QueryString("url"))
        ReturnPage.NavigateUrl = returnUrl
    End Sub
End Class
' </snippet1>