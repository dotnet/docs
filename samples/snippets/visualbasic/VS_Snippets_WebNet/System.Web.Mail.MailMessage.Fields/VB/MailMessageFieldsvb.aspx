<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ IMPORT namespace="System.Web.Mail" %>

<script runat="server">
  
  Sub OnSendMailClick(ByVal sender As Object, ByVal e As EventArgs)

    Dim mail As MailMessage = New MailMessage()
    mail.To = "john@contoso.com"
    mail.From = "marsha@contoso.com"
    mail.Subject = "Hello"
    mail.Body = "This is a test message."
    
    ' <snippet1>
    ' Use the Fields property to add authentication, your username, and your password.
    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "marsha")
    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "secret")
    ' </snippet1>

    ' Name of relay mail server in your domain.
    SmtpMail.SmtpServer = "smarthost"
    SmtpMail.Send(mail)
   
  End Sub


</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>MailMessage.Fields Example</title>
</head >
  <body>
    <form id="form1" runat="server">
    <h3>MailMessage.Fields Example</h3>
      <asp:Button id="SendMail"
        runat="server" 
        onclick="OnSendMailClick" 
        text="Send" 
        tooltip="Click here to send a test E-mail message." />
    </form>
  </body>
</html>

