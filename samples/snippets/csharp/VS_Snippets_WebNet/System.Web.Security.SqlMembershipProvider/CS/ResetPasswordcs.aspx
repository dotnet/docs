<!-- <Snippet8> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Page_Load(object sender, EventArgs args)
{
  if (!Membership.EnablePasswordReset)
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
      Msg.Text = "The user name " + Server.HtmlEncode(UsernameTextBox.Text) + " was not found. Please check the value and reenter your user name.";

      QuestionLabel.Text = "";
      QuestionLabel.Enabled = false;
      AnswerTextBox.Enabled = false;
      ResetPasswordButton.Enabled = false;
    }
    else
    {
      QuestionLabel.Text = user.PasswordQuestion;
      QuestionLabel.Enabled = true;
      AnswerTextBox.Enabled = true;
      ResetPasswordButton.Enabled = true;
    }
}

public void ResetPassword_OnClick(object sender, EventArgs args)
{
  string newPassword = "";

  try
  {
    newPassword = Membership.Provider.ResetPassword(UsernameTextBox.Text, AnswerTextBox.Text);
  }
  catch (NotSupportedException e)
  {
    Msg.Text = "An error has occurred resetting your password: " + e.Message + "." +
               "Please check your values and try again.";
  }
  catch (MembershipPasswordException e)
  {
    Msg.Text = "Invalid password answer. Please reenter the answer and try again.";
    return;
  }
  catch (System.Configuration.Provider.ProviderException e)
  {
    Msg.Text = "The specified user name does not exist. Please check your value and try again.";
  }

  if (newPassword != "")
  {
    Msg.Text = "Password reset. Your new password is: " + Server.HtmlEncode(newPassword);
  }
  else
  {
    Msg.Text = "Password reset failed. Please reenter your values and try again.";
  }
}


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Reset Password</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Reset Password</h3>

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

  <asp:Button id="ResetPasswordButton" Text="Reset Password" 
              OnClick="ResetPassword_OnClick" runat="server" Enabled="false" />

</form>

</body>
</html>
<!-- </Snippet8> -->