<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
void SiteSpecificUserLoggingMethod(string UserName)
{
    // Insert code to record the current date and time
    // when this user was authenticated at the site.
}

void OnLoggedIn(object sender, EventArgs e)
{
    SiteSpecificUserLoggingMethod(Login1.UserName);
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server" OnLoggedIn="OnLoggedIn"></asp:Login>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
