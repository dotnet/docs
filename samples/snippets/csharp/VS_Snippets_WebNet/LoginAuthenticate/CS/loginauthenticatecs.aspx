<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
{
    // Insert code that implements a site-specific custom 
    // authentication method here.
    //
    // This example implementation always returns false.
    return false;
}

private void OnAuthenticate(object sender, AuthenticateEventArgs e)
{
    bool Authenticated = false;
    Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password);

    e.Authenticated = Authenticated;
}

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server"
                OnAuthenticate="OnAuthenticate">
            </asp:Login>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
