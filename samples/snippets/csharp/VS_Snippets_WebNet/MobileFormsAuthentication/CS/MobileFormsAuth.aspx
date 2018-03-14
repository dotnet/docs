<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
private void Login_Click(Object sender, EventArgs e)
{
// Perform Authentication check here by using 
// UserEmail.Value and UserPswd.Value.
    if (Membership.ValidateUser(UserEmail.Text, UserPswd.Text))
    {
        // Set the authorization cookie
        FormsAuthentication.SetAuthCookie(UserEmail.Text, false);
        // Redirect from login page
        MobileFormsAuthentication.RedirectFromLoginPage(UserEmail.Text, true);
    }
    else
    {
        // Notify the user
        lblError.Text = "Login invalid. Please check your credentials";
    }
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <Mobile:Label runat="server">Enter username</Mobile:Label>
        <Mobile:TextBox id="UserEmail" runat="Server"/>
        <Mobile:Label runat="server">Enter password</Mobile:Label>
        <Mobile:TextBox id="UserPswd" runat="Server"/>
        <Mobile:Command ID="Command1" runat="Server" OnClick="Login_Click"  
            SoftkeyLabel="og">Go</Mobile:Command>
        <Mobile:Label runat="server" id="lblError" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->