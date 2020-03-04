<!-- <Snippet9> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Profile" %>
<%@ Import Namespace="System.Configuration.Provider" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>List Enabled Providers</title>
</head>
<body>

<%
foreach (ProviderBase p in ProfileManager.Providers)
  Response.Write(p.Name + ", " + p.GetType() + "<br />");
%>

</body>
</html>
<!-- </Snippet9> -->