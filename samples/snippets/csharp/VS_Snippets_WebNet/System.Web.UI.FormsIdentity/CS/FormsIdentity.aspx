<%--<snippet1>--%>
<%@ Page Language="C#" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Web.Security" %>
<script runat="server">
    protected void Login_Click(object sender, EventArgs e)
    {
        bool isAuthenticated = false;
        if (string.Compare(UserNameTextBox.Text, "UserName", true,
        CultureInfo.InvariantCulture) == 0)
        {
            if (string.Compare(PasswordTextBox.Text, "Password", true,
            CultureInfo.InvariantCulture) == 0)
            {
                isAuthenticated = true;
            }
        }
        else isAuthenticated = false;
        
        // Create the formsIdentity for the user.
        CreateformsIdentity(UserNameTextBox.Text, isAuthenticated);
    }
    private void CreateformsIdentity(string userName, bool isAuthenticated)
    {
        FormsIdentity formsID;
        FormsAuthenticationTicket authenticationTicket;
        
        if (isAuthenticated)
        {
            // If authentication passed, create a ticket 
            // as a Manager that expires in 15 minutes.
            authenticationTicket = new FormsAuthenticationTicket(1, userName,
                DateTime.Now, DateTime.Now.AddMinutes(15), false, "Manager");
        }
        else
        {
            // If authentication failed, create a ticket 
            // as a guest that expired 5 minutes ago.
            authenticationTicket = new FormsAuthenticationTicket(1, userName,
                DateTime.Now, DateTime.Now.Subtract(new TimeSpan(0, 5, 0)),
                false, "Guest");
        }

        // Create form identity from FormsAuthenticationTicket.
        formsID = new FormsIdentity(authenticationTicket);
        Response.Clear();
        Response.Write("Authentication Type: " + formsID.AuthenticationType +
            "<BR>");

        // Get FormsAuthenticationTicket from the FormIdentity
        FormsAuthenticationTicket ticket = formsID.Ticket;
        if (ticket.Expired)
        {
            Response.Write("Authentication failed, so the role is set to " +
                ticket.UserData);
        }
        else
        {
            Response.Write("Authentication succeeded, so the role is set to " +
                ticket.UserData);
        }
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>WebForm1</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <asp:Label id="UserIdLabel" runat="server"
                style="left: 144px; position: absolute; top: 160px">
                User-ID:</asp:Label>
            <asp:Label id="PasswordLabel" runat="server"
                style="left: 144px; position: absolute; top: 200px">
                Password:</asp:Label>
            <asp:TextBox id="UserNameTextBox" runat="server"
                style="left: 232px; position: absolute; top: 160px;
                width:182px; height:22px"></asp:TextBox>
            <asp:TextBox id="PasswordTextBox" runat="server"
                style="left: 232px; position: absolute; top: 200px;
                width:181px; height:22px" TextMode="Password">
                </asp:TextBox>
            <asp:Button id="Login" runat="server" Text="Login"
                style="left: 232px; position: absolute; top: 232px; 
                width:100px" OnClick="Login_Click"></asp:Button>
        </form>
    </body>
</html>
<%--</snippet1>--%>