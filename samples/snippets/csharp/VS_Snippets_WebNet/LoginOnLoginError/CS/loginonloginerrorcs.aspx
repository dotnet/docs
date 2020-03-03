<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
// This custom Login control displays help
// information if the user does not log in
// on the first attempt.
class CustomLogin : Login
{
    override protected void OnLoginError(EventArgs e)
    {
        HelpPageText = "Help with logging in...";
        CreateUserText = "Create a new user...";
        PasswordRecoveryText = "Forgot your password?";
    }
    
    public CustomLogin() 
    {
        CreateUserUrl = "createUser.aspx";
        HelpPageUrl = "loginHelp.aspx";
        PasswordRecoveryUrl = "getPass.aspx";
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
