<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    '<Snippet9>
    For Each s As String In Session.Contents
      Response.Write(String.Format("{0} = {1}<br />", s, Session(s)))
    Next
    '</Snippet9>
    '<Snippet10>
    For Each de As System.Collections.DictionaryEntry In Session.StaticObjects
      Response.Write(String.Format("{0} is of type {1}<br />", de.Key, de.Value.GetType()))
    Next
    '</Snippet10>
    '<Snippet31>
    Dim readOnlySession As Boolean = False
    
    If TypeOf (Context.Handler) Is IReadOnlySessionState Then
      readOnlySession = True
    End If
    '</Snippet31>
    Response.Write(String.Format("readOnlySession = {0}<br />", readOnlySession))
    
    '<Snippet32>
    Dim requiresSession As Boolean = False
    
    If TypeOf (Context.Handler) Is IRequiresSessionState Then
      requiresSession = True
    End If
    '</Snippet32>
    Response.Write(String.Format("requiresSession = {0}<br />", requiresSession))
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html" />
  <title>Sample: Session Contents</title>
</head>
<body>
  <form id="form1" runat="server">
    
  </form>
</body>
</html>
