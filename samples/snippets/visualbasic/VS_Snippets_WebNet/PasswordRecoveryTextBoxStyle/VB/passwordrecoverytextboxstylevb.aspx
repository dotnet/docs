<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Sub PasswordRecovery1_UserLookupError(ByVal sender As Object, ByVal e As System.EventArgs)
        PasswordRecovery1.TextBoxStyle.BackColor = System.Drawing.Color.Red
        PasswordRecovery1.TextBoxStyle.ForeColor = System.Drawing.Color.White
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:passwordrecovery id="PasswordRecovery1" runat="server" 
        onuserlookuperror="PasswordRecovery1_UserLookupError">
        <textboxstyle backcolor="#C0FFC0"></textboxstyle>
    </asp:passwordrecovery>

</form>
</body>
</html>
<!-- </Snippet1> -->
