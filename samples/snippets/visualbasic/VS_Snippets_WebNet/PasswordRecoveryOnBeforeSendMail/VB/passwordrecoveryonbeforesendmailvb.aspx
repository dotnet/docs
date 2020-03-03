<!-- <Snippet1> -->
<%@ page language="VB" %>
<%@ Import namespace="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
    
    Dim passwordRecoveryControl As New PasswordRecoveryOnBeforeSendingEmail
        
    passwordRecoveryControl.ID = "passwordRecoveryControl"
    passwordRecoveryControl.MailDefinition.From = "userAdmin@your.site.name.here"
    PlaceHolder1.Controls.Add(passwordRecoveryControl)
        
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
