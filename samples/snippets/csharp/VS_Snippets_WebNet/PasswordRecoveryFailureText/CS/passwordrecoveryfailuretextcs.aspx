<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PasswordRecovery id="PasswordRecovery1" runat="server" 
            GeneralFailureText="You password cannot be retrieved at this time. Please try again later." 
            QuestionFailureText="Your answer does not match the stored answer. Please try again." 
            UserNameFailureText="We couldn't find that user name. Please try again.">
            <FailureTextStyle backcolor="Red" forecolor="White"></FailureTextStyle>
        </asp:PasswordRecovery>
    </form>
</body>
</html>
<!-- </Snippet1> -->
