<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Login_OnClick(object sender, EventArgs args)
{
  string returnMessage;
  MembershipUser u = Membership.GetUser(UsernameTextbox.Text);

  if (u == null)
  {
    Msg.Text = "Invalid user name. Please check your user name and try again.";
    return;
  }

  if (ValidateLogin(u, PasswordTextbox.Text, out returnMessage))
  {
    FormsAuthentication.RedirectFromLoginPage(UsernameTextbox.Text, NotPublicCheckBox.Checked);
  }
  else
  {
    Msg.Text = returnMessage;
  }
}

public bool ValidateLogin(MembershipUser u, string password, out string returnMessage)
{
  int maxInvalidAttempts = 3;
  bool validated = false;

  if (Membership.Providers[u.ProviderName].ValidateUser(u.UserName, password))
  {
      u.Comment = "0";            // Reset count of invalid validation attempts.
      validated = true;
      returnMessage = "Validated";
  }
  else
  {
    // Increment the count of invalid validation attempts.

    int invalidAttempts = Convert.ToInt32(u.Comment);
    invalidAttempts++;
    u.Comment = invalidAttempts.ToString();


    // Determine the cause of the validation failure and disable the account if
    // there have been too many failed validation attempts.

    if (!u.IsApproved)
    {
      returnMessage = "Your account has been disabled. " +
                      "Please contact your administrator to re-enable your user name.";
    }
    else
    {
      if (invalidAttempts >= maxInvalidAttempts)
      {
        returnMessage = "Too many invalid login attempts. Your account has been disabled. " +
                        "Please contact your administrator to re-enable your user name.";
        u.IsApproved = false;
      }
      else
      {
        returnMessage = "Invalid Password. Please check your password and try again.";
      }
    }
  }

  try
  {
    Membership.Providers[u.ProviderName].UpdateUser(u);
  }
  catch (HttpException)
  {
    returnMessage = "An error occurred communicating with the data source. Please contact your administrator.";
  }

  return validated;
}


</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Login</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Login</h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  Username: <asp:Textbox id="UsernameTextbox" runat="server" /><br />
  Password: <asp:Textbox id="PasswordTextbox" runat="server" TextMode="Password" /><br />
 
  <asp:Button id="LoginButton" Text="Login" OnClick="Login_OnClick" runat="server" />
  <asp:CheckBox id="NotPublicCheckBox" runat="server" /> Check here if this is <span style="text-decoration:underline">not</span> a public computer.

</form>
<br />

</body>
</html>
<!-- </Snippet2> -->
