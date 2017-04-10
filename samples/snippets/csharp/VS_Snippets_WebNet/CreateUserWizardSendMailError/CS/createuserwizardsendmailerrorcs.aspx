<!-- <Snippet1> -->
<%@ page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void SiteSpecificLoggingProcedure(SendMailErrorEventArgs e)
  {
    // Code to log e-mail error, e.Exception.ToString, goes here.
  }

  void Createuserwizard1_SendMailError (object sender, SendMailErrorEventArgs e)
  {
    SiteSpecificLoggingProcedure (e);
    e.Handled = true;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CreateUserWizard.SendMailError sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:createuserwizard id="Createuserwizard1" runat="server" 
        onsendmailerror="Createuserwizard1_SendMailError">
      </asp:createuserwizard>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
