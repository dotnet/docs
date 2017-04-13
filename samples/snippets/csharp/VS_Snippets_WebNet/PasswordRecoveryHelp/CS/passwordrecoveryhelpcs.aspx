<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void PasswordRecovery1_UserLookupError(object sender, EventArgs e)
    {
        PasswordRecovery1.HelpPageText = "Need help with recovering your password?";
        PasswordRecovery1.HyperLinkStyle.BackColor = System.Drawing.Color.DarkGreen;
        PasswordRecovery1.HyperLinkStyle.ForeColor = System.Drawing.Color.White;
    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:passwordrecovery id="PasswordRecovery1" runat="server"
      helppagetext="Help with recovering your password" 
      helppageurl="recoveryHelp.aspx" OnUserLookupError="PasswordRecovery1_UserLookupError">
        <hyperlinkstyle backcolor="#E0E0E0"></hyperlinkstyle>
    </asp:passwordrecovery>

</form>
</body>
</html>
<!-- </Snippet1> -->
