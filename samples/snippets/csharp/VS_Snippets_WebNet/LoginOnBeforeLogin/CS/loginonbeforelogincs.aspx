<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
// This custom Login control checks the user name 
// entered by the user is a valid e-mail address
class CustomLogin : Login
{
    bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
    }

    override protected void OnLoggingIn(System.Web.UI.WebControls.LoginCancelEventArgs e)
    {
        if (!IsValidEmail(UserName)) 
        {
            InstructionText = "You must enter a valid e-mail address.";
            e.Cancel = true;
        }
        else 
        {
            InstructionText = String.Empty;
        }
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
