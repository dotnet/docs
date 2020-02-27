<%@ Register TagPrefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="Samples.AspNet.CS" %>
<!-- <Snippet2> -->
<%@ page language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>MailLink test page</title>
</head>
<body>
  <form id="Form1" runat="server">
    <aspSample:MailLink id="maillink1" Font-Bold="true" 
      ForeColor="Green" Email="someone@example.com" runat="server">
      Mail Webmaster
    </aspSample:MailLink>
  </form>
</body>
</html>
<!-- </Snippet2> -->
