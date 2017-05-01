<!-- <Snippet5> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub CreateUser_OnClick(sender As Object, args As EventArgs)
  ' Create a new 12-character password with 1 non-alphanumeric character.
  Dim password As String = Membership.GeneratePassword(12, 1)

  Try
    ' Create new user.

    Dim newUser As MembershipUser = Membership.CreateUser(UsernameTextbox.Text, password, _
                                                          EmailTextbox.Text)

    Msg.Text = "User <b>" & Server.HtmlEncode(UsernameTextbox.Text) & "</b> created. " & _
               "Your temporary password is " & password & "."
  
  Catch e As MembershipCreateUserException
    Msg.Text = GetErrorMessage(e.StatusCode)
  Catch e As HttpException
    Msg.Text = e.Message
  End Try
End Sub

Public Function GetErrorMessage(status As MembershipCreateStatus) As String

   Select Case status
      Case MembershipCreateStatus.DuplicateUserName
        Return "Username already exists. Please enter a different user name."

      Case MembershipCreateStatus.DuplicateEmail
        Return "A username for that e-mail address already exists. Please enter a different e-mail address."

      Case MembershipCreateStatus.InvalidPassword
        Return "The password provided is invalid. Please enter a valid password value."

      Case MembershipCreateStatus.InvalidEmail
        Return "The e-mail address provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.InvalidAnswer
        Return "The password retrieval answer provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.InvalidQuestion
        Return "The password retrieval question provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.ProviderError
        Return "The authentication provider Returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

      Case MembershipCreateStatus.UserRejected
        Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

      Case Else
        Return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
   End Select
End Function

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Create User</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Create New User</h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <table cellpadding="3" border="0">
    <tr>
      <td>Username:</td>
      <td><asp:Textbox id="UsernameTextbox" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                      ControlToValidate="UserNameTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>

    <tr>
      <td>Email Address:</td>
      <td><asp:Textbox id="EmailTextbox" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="EmailRequiredValidator" runat="server"
                                      ControlToValidate="EmailTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>

    <tr>
      <td></td>
      <td><asp:Button id="CreateUserButton" Text="Create User" OnClick="CreateUser_OnClick" runat="server" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet5> -->