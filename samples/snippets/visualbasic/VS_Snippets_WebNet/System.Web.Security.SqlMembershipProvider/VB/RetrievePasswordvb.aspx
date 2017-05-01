<!-- <Snippet4> -->

<%@ Page Language="VB" %>

<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Net.Mail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Public Sub Page_Load(ByVal sender As Object, ByVal args As EventArgs)

    If Not Membership.EnablePasswordRetrieval Then
      FormsAuthentication.RedirectToLoginPage()
    End If

    Msg.Text = ""

    If Not IsPostBack Then
      Msg.Text = "Please enter a user name."
    Else
      VerifyUsername()
    End If

  End Sub


  Private Sub VerifyUsername()

    Dim user As MembershipUser = Membership.GetUser(UsernameTextBox.Text, False)

    If user Is Nothing Then
      Msg.Text = "The user name " & Server.HtmlEncode(UsernameTextBox.Text) & " was not found. Please check the value and re-enter."

      QuestionLabel.Text = ""
      QuestionLabel.Enabled = False
      AnswerTextBox.Enabled = False
      EmailPasswordButton.Enabled = False
    Else
      QuestionLabel.Text = user.PasswordQuestion
      QuestionLabel.Enabled = True
      AnswerTextBox.Enabled = True
      EmailPasswordButton.Enabled = True
    End If

  End Sub


  Public Sub EmailPassword_OnClick(ByVal sender As Object, ByVal args As EventArgs)

    ' Note: Returning a password in clear text using e-mail is not recommended for
    ' sites that require a high level of security.

    Try
      Dim password As String = Membership.Provider.GetPassword(UsernameTextBox.Text, AnswerTextBox.Text)
      Dim u As MembershipUser = Membership.GetUser(UsernameTextBox.Text)
      EmailPassword(u.Email, password)
      Msg.Text = "Your password was sent via e-mail."
    Catch e As MembershipPasswordException
      Msg.Text = "The password answer is incorrect. Please check the value and try again."
    Catch e As System.Configuration.Provider.ProviderException
      Msg.Text = "An error occurred retrieving your password. Please check your values " & _
                 "and try again."
    End Try

  End Sub


  Private Sub EmailPassword(ByVal email As String, ByVal password As String)

    Try
      Dim Message As MailMessage = New MailMessage("administrator", email)
      Message.Subject = "Your Password"
      Message.Body = "Your password is: " & Server.HtmlEncode(password)
      
      Dim SmtpMail As SmtpClient = New SmtpClient("SMTPSERVER")
      SmtpMail.Send(Message)
    Catch
      Msg.Text = "An exception occurred while sending your password. Please try again."
    End Try

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Sample: Retrieve Password</title>
</head>
<body>
  <form id="form1" runat="server">
    <h3>
      Retrieve Password</h3>
    <asp:Label ID="Msg" runat="server" ForeColor="maroon" /><br />
    Username:
    <asp:TextBox ID="UsernameTextBox" Columns="30" runat="server" AutoPostBack="True" />
    <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server" ControlToValidate="UsernameTextBox"
      ForeColor="red" Display="Static" ErrorMessage="Required" /><br />
    Password Question: <b>
      <asp:Label ID="QuestionLabel" runat="server" /></b><br />
    Answer:
    <asp:TextBox ID="AnswerTextBox" Columns="60" runat="server" Enabled="False" />
    <asp:RequiredFieldValidator ID="AnswerRequiredValidator" runat="server" ControlToValidate="AnswerTextBox"
      ForeColor="red" Display="Static" ErrorMessage="Required" Enabled="False" /><br />
    <asp:Button ID="EmailPasswordButton" Text="Email My Password" OnClick="EmailPassword_OnClick"
      runat="server" Enabled="False" />
  </form>
</body>
</html>
<!-- </Snippet4> -->
