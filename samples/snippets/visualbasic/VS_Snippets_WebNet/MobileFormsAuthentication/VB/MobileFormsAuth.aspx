<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    Private Sub Login_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Perform Authentication check here by using 
        ' UserEmail.Value and UserPswd.Value.
        If (Membership.ValidateUser(UserEmail.Text, UserPswd.Text)) Then
            ' Set the authorization cookie
            FormsAuthentication.SetAuthCookie(UserEmail.Text, False)
            ' Redirect from login page
            MobileFormsAuthentication.RedirectFromLoginPage(UserEmail.Text, True)
        Else
            ' Notify the user
            lblError.Text = "Login invalid. Please check your credentials"
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <Mobile:Label ID="Label1" runat="server">Enter username</Mobile:Label>
        <Mobile:TextBox id="UserEmail" runat="Server"/>
        <Mobile:Label ID="Label2" runat="server">Enter password</Mobile:Label>
        <Mobile:TextBox id="UserPswd" runat="Server"/>
        <Mobile:Command ID="Command1" runat="Server" OnClick="Login_Click"  
            SoftkeyLabel="og">Go</Mobile:Command>
        <Mobile:Label runat="server" id="lblError" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
