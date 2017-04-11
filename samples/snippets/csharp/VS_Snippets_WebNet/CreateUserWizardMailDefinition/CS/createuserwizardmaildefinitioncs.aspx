<!-- <Snippet1> -->
<%@ page language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void Createuserwizard1_SendingMail(object sender, MailMessageEventArgs e)
  {
    // Set MailMessage fields.
    e.Message.IsBodyHtml = false;
    e.Message.Subject = "New user on Web site.";
    // Replace placeholder text in message body with information 
    // provided by the user.
    e.Message.Body = e.Message.Body.Replace("<%PasswordQuestion%>", Createuserwizard1.Question);
    e.Message.Body = e.Message.Body.Replace("<%PasswordAnswer%>",   Createuserwizard1.Answer);  
}
  
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
      CreateUserWizard.MailDefinition sample</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <div>
        <asp:createuserwizard id="Createuserwizard1" runat="server" 
          maildefinition-bodyfilename="MailFile.txt"
          maildefinition-from="userAdmin@your.site.name.here" 
          onsendingmail="Createuserwizard1_SendingMail">
        </asp:createuserwizard>
      </div>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
