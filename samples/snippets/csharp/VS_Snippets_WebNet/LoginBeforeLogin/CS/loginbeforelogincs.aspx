<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.ComponentModel" %>
<%@ Import Namespace="System.Text.RegularExpressions" %>

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
        Login1.InstructionText = "You must enter a valid e-mail address.";
        e.Cancel = true;
    }
    else
    {
        Login1.InstructionText = String.Empty;
    }
}

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server" 
                OnLoggingIn="OnLoggingIn" 
                UserNameLabelText="E-mail Address:" 
                UserNameRequiredErrorMessage="E-mail Address.">
            </asp:Login>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
