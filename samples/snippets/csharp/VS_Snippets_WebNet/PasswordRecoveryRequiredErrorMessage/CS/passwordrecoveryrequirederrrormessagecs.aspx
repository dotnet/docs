<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <p>
      <asp:PasswordRecovery id="PasswordRecovery1" runat="server" 
        AnswerRequiredErrorMessage="You must enter an answer." 
        UserNameRequiredErrorMessage="You must enter a user name.">
      </asp:PasswordRecovery>
    </p>
    <p>
      <asp:ValidationSummary id="ValidationSummary1" runat="server">
      </asp:ValidationSummary>
    </p>
 </form>
</body>
</html>
<!-- </Snippet1> -->

