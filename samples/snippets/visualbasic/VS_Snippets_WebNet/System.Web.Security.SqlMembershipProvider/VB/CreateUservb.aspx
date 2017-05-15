<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub CreateUser_OnClick(sender As Object, args As EventArgs)

  ' Create new user and retrieve create status result.

  Dim status As MembershipCreateStatus
  Dim passwordQuestion As String = ""
  Dim passwordAnswer As String = ""

  If Membership.RequiresQuestionAndAnswer Then
    passwordQuestion = PasswordQuestionTextbox.Text
    passwordAnswer = PasswordAnswerTextbox.Text
  End If

  Try
    Dim newUser As MembershipUser = Membership.CreateUser(UsernameTextbox.Text, PasswordTextbox.Text, _
                                                   EmailTextbox.Text, passwordQuestion, _
                                                   passwordAnswer, True, status)
    If newUser Is Nothing Then
      Msg.Text = GetErrorMessage(status)
    Else
       Response.Redirect("login.aspx")
    End If
  Catch
    Msg.Text = "An exception occurred creating the user."
  End Try

End Sub

Public Function GetErrorMessage(status As MembershipCreateStatus) As String

   Select Case status
   
      Case MembershipCreateStatus.DuplicateUserName:
        Return "Username already exists. Please enter a different user name."

      Case MembershipCreateStatus.DuplicateEmail:
        Return "A username for that e-mail address already exists. Please enter a different e-mail address."

      Case MembershipCreateStatus.InvalidPassword:
        Return "The password provided is invalid. Please enter a valid password value."

      Case MembershipCreateStatus.InvalidEmail:
        Return "The e-mail address provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.InvalidAnswer:
        Return "The password retrieval answer provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.InvalidQuestion:
        Return "The password retrieval question provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.InvalidUserName
        Return "The user name provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.ProviderError:
        Return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

      Case MembershipCreateStatus.UserRejected:
        Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

      Case Else:
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
  <asp:Label id="Msg" ForeColor="maroon" runat="server" />
  <table cellpadding="3" border="0">
    <tr>
      <td>Username:</td>
      <td><asp:Textbox id="UsernameTextbox" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                      ControlToValidate="UserNameTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>Password:</td>
      <td><asp:Textbox id="PasswordTextbox" runat="server" TextMode="Password" /></td>
      <td><asp:RequiredFieldValidator id="PasswordRequiredValidator" runat="server"
                                      ControlToValidate="PasswordTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>Confirm Password:</td>
      <td><asp:Textbox id="PasswordConfirmTextbox" runat="server" TextMode="Password" /></td>
      <td><asp:RequiredFieldValidator id="PasswordConfirmRequiredValidator" runat="server"
                                      ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" />
          <asp:CompareValidator id="PasswordConfirmCompareValidator" runat="server"
                                      ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                                      Display="Static" ControlToCompare="PasswordTextBox"
                                      ErrorMessage="Confirm password must match password." />
      </td>
    </tr>
    <tr>
      <td>Email Address:</td>
      <td><asp:Textbox id="EmailTextbox" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="EmailRequiredValidator" runat="server"
                                      ControlToValidate="EmailTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>


<% If Membership.RequiresQuestionAndAnswer Then %>

    <tr>
      <td>Password Question:</td>
      <td><asp:Textbox id="PasswordQuestionTextbox" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="PasswordQuestionRequiredValidator" runat="server"
                                      ControlToValidate="PasswordQuestionTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>Password Answer:</td>
      <td><asp:Textbox id="PasswordAnswerTextbox" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="PasswordAnswerRequiredValidator" runat="server"
                                      ControlToValidate="PasswordAnswerTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>

<% End If %>


    <tr>
      <td></td>
      <td><asp:Button id="CreateUserButton" Text="Create User" OnClick="CreateUser_OnClick" runat="server" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet2> -->