<!-- <Snippet4> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.Mail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub Page_Load(sender As Object, args As EventArgs)
  If Not Membership.EnablePasswordRetrieval Then
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
    Dim u As MembershipUser = Membership.GetUser(UsernameTextBox.Text, False)

    If u Is Nothing Then
      Msg.Text = "Username " & Server.HtmlEncode(UsernameTextBox.Text) & " not found. Please check the value and re-enter."

      QuestionLabel.Text = ""
      QuestionLabel.Enabled = False
      AnswerTextBox.Enabled = False
      EmailPasswordButton.Enabled = False
    Else
      QuestionLabel.Text = u.PasswordQuestion
      QuestionLabel.Enabled = True
      AnswerTextBox.Enabled = True
      EmailPasswordButton.Enabled = True
    End If
End Sub


Public Sub EmailPassword_OnClick(sender As Object, args As EventArgs)
  Dim u As MembershipUser = Membership.GetUser(UsernameTextBox.Text, False)
  Dim password As String

  If Not u Is Nothing Then
    Try
        password = u.GetPassword(AnswerTextBox.Text)
      Catch e As Exception
        Msg.Text = "An exception occurred retrieving your password: " & Server.HtmlEncode(e.Message)
        Return
    End Try

    EmailPassword(u.Email, password)
    Msg.Text = "Password sent via e-mail."
  Else
    Msg.Text = "Password Answer is not valid. Please check the value and try again."
  End If
End Sub


Private Sub EmailPassword(email As String, password As String)
  Try
    Dim Message As MailMessage = New MailMessage()
    Message.To = email
    Message.From = "administrator"
    Message.Subject = "Your Password"
    Message.Body = "Your password is: " & Server.HtmlEncode(password)

    SmtpMail.SmtpServer = "smarthost"
    SmtpMail.Send(Message)
  Catch 
    Msg.Text = "An exception occurred sending your password. Please try again."
  End Try
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Retrieve Password</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Retrieve Password</h3>

  <asp:Label id="Msg" runat="server" ForeColor="maroon" /><br />

  Username: <asp:Textbox id="UsernameTextBox" Columns="30" runat="server" AutoPostBack="true" />
            <asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                        ControlToValidate="UsernameTextBox" ForeColor="red"
                                        Display="Static" ErrorMessage="Required" /><br />

  Password Question: <b><asp:Label id="QuestionLabel" runat="server" /></b><br />

  Answer: <asp:TextBox id="AnswerTextBox" Columns="60" runat="server" Enabled="false" />
          <asp:RequiredFieldValidator id="AnswerRequiredValidator" runat="server"
                                      ControlToValidate="AnswerTextBox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" Enabled="false" /><br />

  <asp:Button id="EmailPasswordButton" Text="Email My Password" 
              OnClick="EmailPassword_OnClick" runat="server" Enabled="false" />

</form>

</body>
</html>
<!-- </Snippet4> -->