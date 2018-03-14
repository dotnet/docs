<!--<Snippet5>-->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Login_OnClick(object sender, EventArgs args)
{
   if (Membership.ValidateUser(UsernameTextbox.Text, PasswordTextbox.Text))
   {
      Roles.DeleteCookie();
      FormsAuthentication.RedirectFromLoginPage(UsernameTextbox.Text, NotPublicCheckbox.Checked);
   }
   else
     Msg.Text = "User authentication failed. Please check your username and password and try again.";
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
  <asp:CheckBox id="NotPublicCheckbox" runat="server" /> Check here if this is <span style="text-decoration:underline">not</span> a public computer

</form>

</body>
</html>
<!--</Snippet5>-->
