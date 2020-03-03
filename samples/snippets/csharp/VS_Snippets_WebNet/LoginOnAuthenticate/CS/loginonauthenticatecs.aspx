<!-- <Snippet1> -->
<%@ page language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    // This custom login control overloads the OnAuthenticate method
    // to call a site-specific authentication method.    
    class CustomLogin : Login
    {
        private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
        {
            // Insert code that implements a site-specific custom 
            // authentication method here.
            //
            // This example implementation always returns false.
            return false;
        }
        
        override protected void OnAuthenticate(AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            Authenticated = SiteSpecificAuthenticationMethod(UserName, Password);

            e.Authenticated = Authenticated;
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
        <form id="form1" runat="server">
            <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
