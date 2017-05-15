'<Snippet7>
Imports System
Imports System.Web
Imports System.Web.Security

Partial Public Class CreateUser
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub On_CreatedUser(ByVal sender As Object, ByVal e As EventArgs)
        Dim userName As String = CreateUserWizard1.UserName
        If RDO_Manager.Checked Then
            HttpContext.Current.Response.Write(userName)
            Roles.AddUserToRole(userName, "Managers")
        Else
            Roles.AddUserToRole(userName, "Friends")
        End If


        HttpContext.Current.Response.Redirect("~/default.aspx")
    End Sub
End Class

'</Snippet7>