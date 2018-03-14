' <snippet1>
Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim destinationURL = "http://www.contoso.com/default.aspx?user=test"

        NextPage.NavigateUrl = "~/Finish?url=" + Server.UrlEncode(destinationURL)
    End Sub
End Class
' </snippet1>