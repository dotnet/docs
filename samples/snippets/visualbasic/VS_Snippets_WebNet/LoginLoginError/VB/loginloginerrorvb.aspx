<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Sub OnLoginError(ByVal sender As Object, ByVal e As EventArgs)
    Login1.HelpPageText = "Help with logging in..."
    Login1.CreateUserText = "Create a new user..."
    Login1.PasswordRecoveryText = "Forgot your password?"
End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server" 
                CreateUserUrl="createUser.aspx" 
                HelpPageUrl="loginHelp.aspx" 
                PasswordRecoveryUrl="getPass.aspx" 
                OnLoginError="OnLoginError">
            </asp:Login>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
