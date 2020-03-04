<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    ' This custom Login control displays help
    ' informatin if the user does not log in
    ' on the first attempt.
    Class CustomLogin
        Inherits Login
        
        Protected Overrides Sub OnLoginError(ByVal e As EventArgs)
            HelpPageText = "Help with logging in..."
            CreateUserText = "Create a new user..."
            PasswordRecoveryText = "Forgot your password?"
        End Sub
        
        Sub New()
            CreateUserUrl = "createUser.aspx"
            HelpPageUrl = "loginHelp.aspx"
            PasswordRecoveryUrl = "getPass.aspx"
        End Sub
        
    End Class
    ' Add the custom login control to the page.
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim loginControl As New CustomLogin

        loginControl.ID = "loginControl"

        PlaceHolder1.Controls.Add(loginControl)
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="Form1" runat="server">
    <asp:placeholder id="Placeholder1" runat="Server"></asp:placeholder>
</form>
</body>
</html>
<!-- </Snippet1> -->
