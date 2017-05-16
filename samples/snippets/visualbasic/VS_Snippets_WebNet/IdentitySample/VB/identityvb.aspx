<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ Import namespace="System.Security.Principal" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
<script runat="server">

Public Function WillFlowAcrossNetwork(w As WindowsIdentity) As Boolean
  For Each s As SecurityIdentifier In w.Groups
    If s.IsWellKnown(WellKnownSidType.InteractiveSid) Then Return True
    If s.IsWellKnown(WellKnownSidType.BatchSid)       Then Return True
    If s.IsWellKnown(WellKnownSidType.ServiceSid)     Then Return True
  Next

  Return False
End Function

</script>
</head>
<body>
<%
  Dim current As WindowsIdentity =  WindowsIdentity.GetCurrent()
  Response.Write(current.Name & ", " & WillFlowAcrossNetwork(current) & "<br />")
%>
</body>
</html>
<!--</Snippet1>-->