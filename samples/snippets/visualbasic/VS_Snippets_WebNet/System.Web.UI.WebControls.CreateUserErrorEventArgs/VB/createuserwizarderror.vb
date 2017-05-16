' <snippet2>
Partial Class CreateUserWizardErrorvb_aspx
    Inherits System.Web.UI.Page

    Protected Sub OnCreateUserError(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CreateUserErrorEventArgs)

        Select Case (e.CreateUserError)

            Case MembershipCreateStatus.DuplicateUserName
                Label1.Text = "Username already exists. Please enter a different user name."


            Case MembershipCreateStatus.DuplicateEmail
                Label1.Text = "A username for that e-mail address already exists. Please enter a different e-mail address."


            Case MembershipCreateStatus.InvalidPassword
                Label1.Text = "The password provided is invalid. Please enter a valid password value."


            Case MembershipCreateStatus.InvalidEmail
                Label1.Text = "The e-mail address provided is invalid. Please check the value and try again."


            Case MembershipCreateStatus.InvalidAnswer
                Label1.Text = "The password retrieval answer provided is invalid. Please check the value and try again."


            Case MembershipCreateStatus.InvalidQuestion
                Label1.Text = "The password retrieval question provided is invalid. Please check the value and try again."


            Case MembershipCreateStatus.InvalidUserName
                Label1.Text = "The user name provided is invalid. Please check the value and try again."


            Case MembershipCreateStatus.ProviderError
                Label1.Text = "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."


            Case MembershipCreateStatus.UserRejected
                Label1.Text = "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

            Case Else
                Label1.Text = "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."

        End Select

    End Sub

End Class
' </snippet2>
