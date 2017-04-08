' <snippet6>
Imports System
Imports System.Web
Imports System.Web.Security


Partial Class ProfileInfo
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        Dim Profile As ProfileCommon = TryCast(HttpContext.Current.Profile, ProfileCommon)

        If HttpContext.Current.User.Identity.IsAuthenticated Then

            Label1.Text = HttpContext.Current.User.Identity.Name
            Dim roles As String() = _
                System.Web.Security.Roles.GetRolesForUser()

            Label2.Text = ""
            For Each r As String In roles
                Label2.Text += r + " "
            Next

            Label3.Text = Profile.FirstName()
            Label4.Text = Profile.LastName

            Label5.Text = Profile.PhoneNumber
        Else
            Label1.Text = "User is not Authenticated"
            Label1.ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Label1.Text = HttpContext.Current.User.Identity.Name
            Dim roles As String() = _
                System.Web.Security.Roles.GetRolesForUser()
            Label2.Text = ""
            For Each r As String In roles
                Label2.Text += r + " "
            Next
            Label3.Text = Profile.FirstName
            Label4.Text = Profile.LastName
            Label5.Text = Profile.PhoneNumber
        Else
            Label1.Text = "User is not Authenticated"
            Label1.ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Profile.FirstName = TextBox1.Text
            Profile.LastName = TextBox2.Text
            Profile.PhoneNumber = TextBox3.Text
        End If
    End Sub
End Class
' </snippet6>
