<!-- <Snippet4> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.Mail" %>
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
    Msg.Text = "Please supply a username.";
  }
  else
  {
    VerifyUsername();
  }
}


public void VerifyUsername()
{
    MembershipUser u = Membership.GetUser(UsernameTextBox.Text, false);

    if (u == null)
    {
      Msg.Text = "Username " + Server.HtmlEncode(UsernameTextBox.Text) + " not found. Please check the value and re-enter.";

      QuestionLabel.Text = "";
      QuestionLabel.Enabled = false;
      AnswerTextBox.Enabled = false;
      EmailPasswordButton.Enabled = false;
    }
    else
    {
      QuestionLabel.Text = u.PasswordQuestion;
      QuestionLabel.Enabled = true;
      AnswerTextBox.Enabled = true;
      EmailPasswordButton.Enabled = true;
    }
}


public void EmailPassword_OnClick(object sender, EventArgs args)
{
  MembershipUser u = Membership.GetUser(UsernameTextBox.Text, false);
  string password;

  if (u != null)
  {
    try
    {
      password = u.GetPassword(AnswerTextBox.Text);
    }
    catch (Exception e)
    {
      Msg.Text = "An exception occurred retrieving your password: " + Server.HtmlEncode(e.Message);
      return;
    }

    EmailPassword(u.Email, password);
    Msg.Text = "Password sent via e-mail.";
  }
  else
  {
    Msg.Text = "Password Answer is not valid. Please check the value and try again.";
  }
}


private void EmailPassword(string email, string password)
{
  try
  {
    MailMessage Message = new MailMessage();
    Message.To = email;
    Message.From = "administrator";
    Message.Subject = "Your Password";
    Message.Body = "Your password is: " + Server.HtmlEncode(password);

    SmtpMail.SmtpServer = "smarthost";
    SmtpMail.Send(Message);
  }
  catch 
  {
    Msg.Text = "An exception occurred sending your password. Please try again.";
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