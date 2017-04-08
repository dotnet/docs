<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.ComponentModel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
bool IsValidEmail(string strIn)
{
    // Return true if strIn is in valid e-mail format.
    return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
}

void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
{
    if (!IsValidEmail(Login1.UserName))
    {
        Login1.InstructionText = "Enter a valid e-mail address.";
        Login1.InstructionTextStyle.ForeColor = System.Drawing.Color.RosyBrown;
        e.Cancel = true;
    }
    else
    {
        Login1.InstructionText = String.Empty;
    }
}

void OnLoginError(object sender, EventArgs e)
{
    Login1.HelpPageText = "Help with logging in...";
    Login1.PasswordRecoveryText = "Forgot your password?";
}
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

