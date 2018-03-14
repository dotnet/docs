<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Private Sub Login_Click(sender As Object, e As EventArgs)
  
    ' Create a custom FormsAuthenticationTicket containing
    ' application specific data for the user.

        Dim username As String = UserNameTextBox.Text
        Dim password As String = UserPassTextBox.Text
        Dim isPersistent As Boolean = False

    If Membership.ValidateUser(username, password) Then
    
      Dim userData As String = "ApplicationSpecific data for this user."

      Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, _
        username, _
        DateTime.Now, _
        DateTime.Now.AddMinutes(30), _
        isPersistent, _
        userData, _
        FormsAuthentication.FormsCookiePath)

      ' Encrypt the ticket.
      Dim encTicket As String = FormsAuthentication.Encrypt(ticket)

      ' Create the cookie.
      Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, encTicket))

      ' Redirect back to original URL.
      Response.Redirect(FormsAuthentication.GetRedirectUrl(username, isPersistent))
    Else    
      Msg.Text = "Login failed. Please check your user name and password and try again."
    End If
  End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Forms Authentication Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <span style="BACKGROUND:#80ff80; font-weight:bold"> 
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