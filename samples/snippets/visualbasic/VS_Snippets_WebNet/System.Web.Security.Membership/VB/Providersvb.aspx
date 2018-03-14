<!-- <Snippet7> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Configuration.Provider" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>List Enabled Providers</title>
</head>
<body>

<%
For Each p As ProviderBase In Membership.Providers
  Response.Write(p.Name & ", " & p.GetType().ToString() & "<br />")
Next
%>

</body>
</html>
<!-- </Snippet7> -->