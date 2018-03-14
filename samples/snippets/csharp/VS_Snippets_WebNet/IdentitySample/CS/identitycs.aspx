<!--<Snippet1>-->
<%@ Page Language="C#" %>
<%@ Import namespace="System.Security.Principal" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
<script runat="server">

public bool WillFlowAcrossNetwork(WindowsIdentity w)
{
  foreach (SecurityIdentifier s in w.Groups)
  {
    if (s.IsWellKnown(WellKnownSidType.InteractiveSid)) { return true; }
    if (s.IsWellKnown(WellKnownSidType.BatchSid))       { return true; }
    if (s.IsWellKnown(WellKnownSidType.ServiceSid))     { return true; }
  }

  return false;
}

</script>
</head>
<body>
<%
  WindowsIdentity current =  WindowsIdentity.GetCurrent();
  Response.Write(current.Name + ", " + WillFlowAcrossNetwork(current) + "<br />");
%>
</body>
</html>
<!--</Snippet1>-->