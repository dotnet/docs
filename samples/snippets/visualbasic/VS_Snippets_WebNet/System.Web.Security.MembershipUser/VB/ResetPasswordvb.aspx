<!-- <Snippet5> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim u As MembershipUser

Public Sub Page_Load(sender As Object, args As EventArgs)
  If Not Membership.EnablePasswordReset Then
    FormsAuthentication.RedirectToLoginPage()
  End If

  Msg.Text = ""

  If Not IsPostBack Then
    Msg.Text = "Please supply a username."
  Else
    VerifyUsername()
  End If
End Sub

Public Sub VerifyUsername()
    u = Membership.GetUser(UsernameTextBox.Text, False)

    If u Is Nothing Then
      Msg.Text = "Username " & Server.HtmlEncode(UsernameTextBox.Text) & " not found. Please check the value and re-enter."

      QuestionLabel.Text = ""
      QuestionLabel.Enabled = False
      AnswerTextBox.Enabled = False
      ResetPasswordButton.Enabled = False
    Else
      QuestionLabel.Text = u.PasswordQuestion
      QuestionLabel.Enabled = True
      AnswerTextBox.Enabled = True
      ResetPasswordButton.Enabled = True
    End If
End Sub

Public Sub ResetPassword_OnClick(sender As Object, args As EventArgs)
  Dim newPassword As String
  u = Membership.GetUser(UsernameTextBox.Text, False)

  If u Is Nothing Then
    Msg.Text = "Username " & Server.HtmlEncode(UsernameTextBox.Text) & " not found. Please check the value and re-enter."
    Return
  End If

  Try
    newPassword = u.ResetPassword(AnswerTextBox.Text)
  Catch e As MembershipPasswordException
    Msg.Text = "Invalid password answer. Please re-enter and try again."
    Return
  Catch e As Exception
    Msg.Text = e.Message
    Return
  End Try

  If Not newPassword Is Nothing Then
    Msg.Text = "Password reset. Your new password is: " & Server.HtmlEncode(newPassword)
  Else
    Msg.Text = "Password reset failed. Please re-enter your values and try again."
  End If
End Sub


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Reset Password</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Retrieve Password</h3>

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
<!-- </Snippet5> -->