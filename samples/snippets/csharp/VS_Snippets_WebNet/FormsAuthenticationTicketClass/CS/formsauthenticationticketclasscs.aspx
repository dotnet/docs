<!--<Snippet1>-->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  private void Login_Click(Object sender, EventArgs e)
  {
    // Create a custom FormsAuthenticationTicket containing
    // application specific data for the user.

    string username     = UserNameTextBox.Text;
    string password     = UserPassTextBox.Text;
    bool   isPersistent = false;

    if (Membership.ValidateUser(username, password))
    {
      string userData = "ApplicationSpecific data for this user.";

      FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        username,
        DateTime.Now,
        DateTime.Now.AddMinutes(30),
        isPersistent,
        userData,
        FormsAuthentication.FormsCookiePath);

      // Encrypt the ticket.
      string encTicket = FormsAuthentication.Encrypt(ticket);

      // Create the cookie.
      Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

      // Redirect back to original URL.
      Response.Redirect(FormsAuthentication.GetRedirectUrl(username, isPersistent));
    }
    else
    {
      Msg.Text = "Login failed. Please check your user name and password and try again.";
    }
  }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Forms Authentication Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <span style="BACKGROUND: #80ff80; font-weight:bold"> 
            Login Page
        </span> 
        <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />
        <table border="0">
            <tbody>
                <tr>
                    <td>Username:</td>
                    <td><asp:TextBox id="UserNameTextBox" runat="server" /></td>
                    <td>
                      <asp:RequiredFieldValidator id="RequiredFieldValidator1" 
                                                  runat="server" ErrorMessage="*" 
                                                  Display="Static" 
                                                  ControlToValidate="UserNameTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox id="UserPassTextBox" TextMode="Password" runat="server" /></td>
                    <td>
                      <asp:RequiredFieldValidator id="RequiredFieldValidator2" 
                                                  runat="server" ErrorMessage="*" 
                                                  Display="Static" 
                                                  ControlToValidate="UserPassTextBox" />
                    </td>
                </tr>
            </tbody>
        </table>
        <input type="submit" value="Login" runat="server" onserverclick="Login_Click" />
    </form>
</body>
</html>
<!--</Snippet1>-->