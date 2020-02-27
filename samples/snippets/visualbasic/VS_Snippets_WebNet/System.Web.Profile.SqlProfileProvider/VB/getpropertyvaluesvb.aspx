<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Profile" %>
<%@ Import Namespace="System.Configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Profile Sample: Properties and Values</title>
</head>
<body>
<h3>Properties and Values</h3>

<%
'<Snippet1>
  Dim p As SqlProfileProvider = _
    CType(Profile.Providers("SqlProvider"), SqlProfileProvider)

  Dim pvalues As SettingsPropertyValueCollection = _
    p.GetPropertyValues(Profile.Context, ProfileBase.Properties)

  For Each pval As SettingsPropertyValue In pvalues
    Response.Write(pval.Name & " = " & pval.PropertyValue.ToString() & "<br />")
  Next
'</Snippet1>
%>

</body>
</html>