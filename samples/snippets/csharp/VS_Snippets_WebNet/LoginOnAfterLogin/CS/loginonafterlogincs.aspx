<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
// This custom Login control uses a site-specific method
// to record the current date and time when users are 
// authenticated at the site.

class CustomLogin : Login
{
    private void SiteSpecificUserLoggingMethod(string UserName)
    {
        // Insert code to record the current date and time
        // when this user was authenticated at the site.
    }
    
    override protected void OnLoggedIn(EventArgs e)
    {
        SiteSpecificUserLoggingMethod(UserName);
    }
}
    // Add the custom login control to the page.
    void Page_Load(object sender, EventArgs e) 
    {
        CustomLogin loginControl = new CustomLogin();
        loginControl.ID = "loginControl";
        Placeholder1.Controls.Add(loginControl);
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="Form1" runat="server">
            <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
