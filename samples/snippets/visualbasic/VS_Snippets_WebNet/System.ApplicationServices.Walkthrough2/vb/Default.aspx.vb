' <Snippet3>
Imports System
Imports System.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            LoggedId.Text = HttpContext.Current.User.Identity.Name + " you are logged in"
        End If

    End Sub
End Class
' </Snippet3>