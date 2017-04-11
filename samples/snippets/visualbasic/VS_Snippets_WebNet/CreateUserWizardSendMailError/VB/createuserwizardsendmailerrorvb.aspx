<!-- <Snippet1> -->
<%@ page language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  Sub SiteSpecificLoggingProcedure(ByVal e As SendMailErrorEventArgs)
    'Code to log e-mail error, e.Exception.ToString, goes here.
  End Sub
  
  Sub Createuserwizard1_SendMailError1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SendMailErrorEventArgs)
    SiteSpecificLoggingProcedure(e)
    e.Handled = True
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CreateUserWizard.SendMailError sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:createuserwizard id="Createuserwizard1" runat="server" 
        onsendmailerror="Createuserwizard1_SendMailError1">
      </asp:createuserwizard>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
