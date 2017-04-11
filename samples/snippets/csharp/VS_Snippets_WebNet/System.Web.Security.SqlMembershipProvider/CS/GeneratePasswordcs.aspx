<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%
  // <Snippet9>
  SqlMembershipProvider p = (SqlMembershipProvider)Membership.Provider;
  string newPassword = p.GeneratePassword();
  // </Snippet9>
  Response.Write(newPassword);
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>