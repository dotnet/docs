<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
void OnLoginError(object sender, EventArgs e)
{
    Login1.PasswordRecoveryText = "Did you forget your password?";
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server" 
                PasswordRecoveryText="Forgot your password?" 
                PasswordRecoveryUrl="getPass.aspx" 
                OnLoginError="OnLoginError">
            </asp:Login>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
