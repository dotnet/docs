<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.ComponentModel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Function IsValidEmail(ByVal strIn As String) As Boolean
    ' Return true if strIn is in valid e-mail format.
    Return Regex.IsMatch(strIn, ("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
End Function

Sub OnLoggingIn(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
    If Not IsValidEmail(Login1.UserName) Then
        Login1.InstructionText = "Enter a valid e-mail address."
        Login1.InstructionTextStyle.ForeColor = System.Drawing.Color.RosyBrown
        e.Cancel = True
    Else
        Login1.InstructionText = String.Empty
    End If
End Sub

Sub OnLoginError(ByVal sender As Object, ByVal e As EventArgs)
    Login1.HelpPageText = "Help with logging in..."
    Login1.PasswordRecoveryText = "Forgot your password?"
End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server" 
                BorderStyle="Solid" 
                BackColor="#F7F7DE" 
                BorderWidth="1px"
                BorderColor="#CCCC99" 
                Font-Size="10pt" 
                Font-Names="Verdana" 
                CreateUserText="Create a new user..."
                CreateUserUrl="newUser.aspx" 
                HelpPageUrl="help.aspx"
                PasswordRecoveryUrl="getPass.aspx" 
                UserNameLabelText="E-mail address:" 
                OnLoggingIn="OnLoggingIn"
                OnLoginError="OnLoginError" >
                <TitleTextStyle Font-Bold="True" 
                    ForeColor="#FFFFFF" 
                    BackColor="#6B696B">
                </TitleTextStyle>
            </asp:Login>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
