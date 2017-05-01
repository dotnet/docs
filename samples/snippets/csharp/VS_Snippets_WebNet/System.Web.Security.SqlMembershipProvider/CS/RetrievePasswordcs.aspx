<!-- <Snippet4> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Net.Mail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Page_Load(object sender, EventArgs args)
{
  if (!Membership.EnablePasswordRetrieval)
  {
    FormsAuthentication.RedirectToLoginPage();
  }

  Msg.Text = "";

  if (!IsPostBack)
  {
    Msg.Text = "Please enter a user name.";
  }
  else
  {
    VerifyUsername();
  }
}


public void VerifyUsername()
{
    MembershipUser user = Membership.GetUser(UsernameTextBox.Text, false);

    if (user == null)
    {
      Msg.Text = "The user name " + Server.HtmlEncode(UsernameTextBox.Text) + " was not found. Please check the value and re-enter.";

      QuestionLabel.Text = "";
      QuestionLabel.Enabled = false;
      AnswerTextBox.Enabled = false;
      EmailPasswordButton.Enabled = false;
    }
    else
    {
      QuestionLabel.Text = user.PasswordQuestion;
      QuestionLabel.Enabled = true;
      AnswerTextBox.Enabled = true;
      EmailPasswordButton.Enabled = true;
    }
}


public void EmailPassword_OnClick(object sender, EventArgs args)
{
  // Note: Returning a password in clear text using e-mail is not recommended for
  // sites that require a high level of security.

  try
  {
    string password = Membership.Provider.GetPassword(UsernameTextBox.Text, AnswerTextBox.Text);
    MembershipUser u = Membership.GetUser(UsernameTextBox.Text);
    EmailPassword(u.Email, password);
    Msg.Text = "Your password was sent via e-mail.";
  }
  catch (MembershipPasswordException e)
  {
    Msg.Text = "The password answer is incorrect. Please check the value and try again.";
  }
  catch (System.Configuration.Provider.ProviderException e)
  {
    Msg.Text = "An error occurred retrieving your password. Please check your values " +
               "and try again.";
  }
}


private void EmailPassword(string email, string password)
{
  try
  {
    MailMessage Message = new MailMessage("administrator", email);
    Message.Subject = "Your Password";
    Message.Body = "Your password is: " + Server.HtmlEncode(password);

    SmtpClient SmtpMail = new SmtpClient("SMTPSERVER");
    SmtpMail.Send(Message);
  }
  catch 
  {
    Msg.Text = "An exception occurred while sending your password. Please try again.";
  }
}

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