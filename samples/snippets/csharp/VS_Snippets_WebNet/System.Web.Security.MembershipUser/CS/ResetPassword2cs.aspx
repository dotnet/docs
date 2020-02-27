<!-- <Snippet6> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

MembershipUser u;

public void Page_Load(object sender, EventArgs args)
{
  if (!Membership.EnablePasswordReset)
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
    u = Membership.GetUser(UsernameTextBox.Text, false);

    if (u == null)
    {
      Msg.Text = "Username " + Server.HtmlEncode(UsernameTextBox.Text) + " not found. Please check the value and re-enter.";

      ResetPasswordButton.Enabled = false;
    }
    else
    {
      ResetPasswordButton.Enabled = true;
    }
}

public void ResetPassword_OnClick(object sender, EventArgs args)
{
  string newPassword;

  u = Membership.GetUser(UsernameTextBox.Text, false);

  if (u == null)
  { 
    Msg.Text = "Username " + Server.HtmlEncode(UsernameTextBox.Text) + " not found. Please check the value and re-enter.";
    return;
  }

  try
  {
    newPassword = u.ResetPassword();
  }
  catch (MembershipPasswordException e)
  {
    Msg.Text = "Invalid password answer. Please re-enter and try again.";
    return;
  }
  catch (Exception e)
  {
    Msg.Text = e.Message;
    return;
  }

  if (newPassword != null)
  {
    Msg.Text = "Password reset. Your new password is: " + Server.HtmlEncode(newPassword);
  }
  else
  {
    Msg.Text = "Password reset failed. Please re-enter your values and try again.";
  }
}


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Reset Password</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Retrieve Password</h3>

  <asp:Label id="Msg" runat="server" ForeColor="maroon" /><br />

  Username: <asp:Textbox id="UsernameTextBox" Columns="30" runat="server" AutoPostBack="true" />
            <asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                        ControlToValidate="UsernameTextBox" ForeColor="red"
                                        Display="Static" ErrorMessage="Required" /><br />

  <asp:Button id="ResetPasswordButton" Text="Reset Password" 
              OnClick="ResetPassword_OnClick" runat="server" Enabled="false" />

</form>

</body>
</html>
<!-- </Snippet6> -->