<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Sub Page_Load(sender As Object, e As EventArgs)
        Welcome.InnerHtml = "Hello, " + _
            Server.HtmlEncode(User.Identity.Name)
    
       Dim id As FormsIdentity = CType(User.Identity, FormsIdentity) 
       Dim ticket As FormsAuthenticationTicket = id.Ticket 

       cookiePath.Text = ticket.CookiePath
       expireDate.Text = ticket.Expiration.ToString()
       expired.Text = ticket.Expired.ToString()
       isPersistent.Text = ticket.IsPersistent.ToString()
       issueDate.Text = ticket.IssueDate.ToString()
       name.Text = ticket.Name
       userData.Text = ticket.UserData
       version.Text = ticket.Version.ToString()
    End Sub

    Sub Signout_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Response.Write("Logged out - cookie deleted.")
    End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Forms Authentication</title>
</head>
<body>
    <h3>Forms Authentication Example</h3>
    <span id="Welcome" runat="server"> </span>
    <form id="form1" runat="server">
        <input type="submit" value="Signout" runat="server" onserverclick="Signout_Click" />
        <h3>Forms Authentication Ticket Properties</h3> 
            <table>
                <tbody>
                    <tr>
                        <td>
                            CookiePath: 
                        </td>
                        <td><asp:Label id="cookiePath" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Expiration: 
                        </td>
                        <td><asp:Label id="expireDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Expired: 
                        </td>
                        <td><asp:Label id="expired" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            IsPersistent: 
                        </td>
                        <td><asp:Label id="isPersistent" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            IssueDate: 
                        </td>
                        <td><asp:Label id="issueDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Name: 
                        </td>
                        <td><asp:Label id="name" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            UserData: 
                        </td>
                        <td><asp:Label id="userData" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Version: 
                        </td>
                        <td><asp:Label id="version" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <p>
            </p>
    </form>
</body>
</html>
<!--</Snippet1>-->