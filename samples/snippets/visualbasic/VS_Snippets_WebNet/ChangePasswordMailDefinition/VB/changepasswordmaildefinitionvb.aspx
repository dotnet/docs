<!-- <Snippet1> -->
<%@ page language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  Sub Changepassword1_SendingMail(ByVal sender As Object, ByVal e As MailMessageEventArgs)
        ' Set mail message fields.
        e.Message.Subject = "New user on Web site."
        ' Replace placeholder text in message body with information 
        '  provided by the user. 
        e.Message.Body = e.Message.Body.Replace("<%ChangedDate%>", DateTime.Now.ToString())
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:changepassword id="Changepassword1" runat="server" 
          maildefinition-bodyfilename="~/MailFiles/mailfile.txt"
          maildefinition-from="userAdmin@your.site.name.here" 
          onsendingmail="Changepassword1_SendingMail">
      </asp:changepassword>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
