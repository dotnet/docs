<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

bool IsValidEmail(string strIn)
{
    // Return true if strIn is in valid e-mail format.
    return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
}

void PasswordRecovery1_VerifyingUser(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
{
    if (!IsValidEmail(PasswordRecovery1.UserName))
    {
        PasswordRecovery1.UserNameInstructionText = "You must enter a valid e-mail address.";
        e.Cancel = true;
    }
    else
    {
            PasswordRecovery1.UserNameInstructionText = "Enter your User Name to receive your password.";
    }
}

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:passwordrecovery id="PasswordRecovery1" 
        runat="server" 
        onverifyinguser="PasswordRecovery1_VerifyingUser">
      </asp:passwordrecovery>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
