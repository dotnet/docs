 ' <snippet1>
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace Samples.AspNet.Controls

    NotInheritable Public Class CustomLogin
        Inherits Login

        Public Sub New() 
        End Sub 'New

        Protected Overrides Sub OnLoggingIn(ByVal e As LoginCancelEventArgs) 

            ' Set the Membership provider for the Login control from a DropDownList.
            Dim list As DropDownList = CType(Me.FindControl("domain"), DropDownList)
            Me.MembershipProvider = list.SelectedValue
            MyBase.OnLoggingIn(e)

        End Sub 'OnLoggingIn


        Protected Overrides Sub CreateChildControls() 

            LayoutTemplate = New MyTemplate()
            MyBase.CreateChildControls()

        End Sub 'CreateChildControls
    End Class 'CustomLogin

    ' A Template that contains the child controls.
    Public Class MyTemplate
        Implements ITemplate

        Sub InstantiateIn(ByVal container As Control)  Implements ITemplate.InstantiateIn
            ' A TextBox for the user name.
            Dim username As New TextBox()
            username.ID = "username"

            ' A TextBox for the password.
            Dim password As New TextBox()
            password.ID = "password"

            ' A CheckBox to remember the user on subsequent visits.
            Dim remember As New CheckBox()
            remember.ID = "RememberMe"
            remember.Text = "Don't forget me!"

            ' Failure Text.
            Dim failure As New Literal()
            failure.ID = "FailureText"

            ' A DropDownList to choose the Membership provider.
            Dim domain As New DropDownList()
            domain.ID = "Domain"
            domain.Items.Add(New ListItem("SqlMembers"))
            domain.Items.Add(New ListItem("SqlMembers2"))

            ' A Button to log in.
            Dim submit As New Button()
            submit.CommandName = "login"
            submit.Text = "LOGIN"

            container.Controls.Add(New LiteralControl("UserName:"))
            container.Controls.Add(username)
            container.Controls.Add(New LiteralControl("<br>Password:"))
            container.Controls.Add(password)
            container.Controls.Add(New LiteralControl("<br>"))
            container.Controls.Add(remember)
            container.Controls.Add(New LiteralControl("<br>Domain:"))
            container.Controls.Add(domain)
            container.Controls.Add(New LiteralControl("<br>"))
            container.Controls.Add(failure)
            container.Controls.Add(New LiteralControl("<br>"))
            container.Controls.Add(submit)

        End Sub 'ITemplate.InstantiateIn
    End Class 'MyTemplate
End Namespace
' </snippet1>