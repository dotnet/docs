<!-- <Snippet8> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub Page_Load(sender As Object, args As EventArgs)

  If Not Membership.EnablePasswordReset Then
    FormsAuthentication.RedirectToLoginPage()
  End If

  Msg.Text = ""

  If Not IsPostBack Then
    Msg.Text = "Please enter a user name."
  Else
    VerifyUsername()
  End If

End Sub


Public Sub VerifyUsername()

    Dim user As MembershipUser = Membership.GetUser(UsernameTextBox.Text, False)

    If user Is Nothing Then
      Msg.Text = "The user name " & Server.HtmlEncode(UsernameTextBox.Text) & " was not found. Please check the value and reenter your user name."

      QuestionLabel.Text = ""
      QuestionLabel.Enabled = False
      AnswerTextBox.Enabled = False
      ResetPasswordButton.Enabled = False
    Else
      QuestionLabel.Text = user.PasswordQuestion
      QuestionLabel.Enabled = True
      AnswerTextBox.Enabled = True
      ResetPasswordButton.Enabled = True
    End If

End Sub


Public Sub ResetPassword_OnClick(sender As Object, args As EventArgs)

  Dim newPassword As String = ""

  Try
    newPassword = Membership.Provider.ResetPassword(UsernameTextBox.Text, AnswerTextBox.Text)
  Catch e As NotSupportedException
    Msg.Text = "An error has occurred resetting your password: " & e.Message & "." & _
               "Please check your values and try again."
  Catch e As MembershipPasswordException
    Msg.Text = "Invalid password answer. Please reenter the answer and try again."
    Return
  Catch e As System.Configuration.Provider.ProviderException
    Msg.Text = "The specified user name does not exist. Please check your value and try again."
  End Try

  If newPassword <> "" Then
    Msg.Text = "Password reset. Your new password is: " & Server.HtmlEncode(newPassword)
  Else
    Msg.Text = "Password reset failed. Please reenter your values and try again."
  End If

End Sub


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Reset Password</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Reset Password</h3>

  <asp:Label id="Msg" runat="server" ForeColor="maroon" /><br />

  Username: <asp:Textbox id="UsernameTextBox" Columns="30" runat="server" AutoPostBack="True" />
            <asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                        ControlToValidate="UsernameTextBox" ForeColor="red"
                                        Display="Static" ErrorMessage="Required" /><br />

  Password Question: <b><asp:Label id="QuestionLabel" runat="server" /></b><br />

  Answer: <asp:TextBox id="AnswerTextBox" Columns="60" runat="server" Enabled="False" />
          <asp:RequiredFieldValidator id="AnswerRequiredValidator" runat="server"
                                      ControlToValidate="AnswerTextBox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" Enabled="False" /><br />

  <asp:Button id="ResetPasswordButton" Text="Reset Password" 
              OnClick="ResetPassword_OnClick" runat="server" Enabled="False" />

</form>

</body>
</html>
<!-- </Snippet8> -->