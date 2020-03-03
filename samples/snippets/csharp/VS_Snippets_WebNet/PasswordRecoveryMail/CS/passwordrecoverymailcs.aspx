<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
  {
    e.Message.IsBodyHtml = false;
    e.Message.Subject = "New password on Web site.";
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:passwordrecovery 
         id="PasswordRecovery1" 
         runat="server"
         maildefinition-from="userAdmin@your.site.name.here"
         onsendingmail="PasswordRecovery1_SendingMail">
      </asp:passwordrecovery>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
