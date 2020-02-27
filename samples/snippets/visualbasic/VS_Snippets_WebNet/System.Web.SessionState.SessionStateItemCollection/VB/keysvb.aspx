<%@ Page Language="VB" %>
<%@ Import Namespace="System.Configuration" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%

'<Snippet1>
Dim items As SessionStateItemCollection = New SessionStateItemCollection()

items("LastName") = "Wilson"
items("FirstName") = "Dan"

For Each s As String In items.Keys
  Response.Write("items(""" & s & """) = " & items(s).ToString() & "<br />")
Next
'</Snippet1>

'<Snippet2>
Dim sessionItems As SessionStateItemCollection = New SessionStateItemCollection()

sessionItems("ZipCode") = "98072"
sessionItems("Email") = "someone@example.com"

For i As Integer = 0 To items.Count - 1
  Response.Write("sessionItems(" & i & ") = " & sessionItems(i).ToString() & "<br />")
Next
'</Snippet2>

%>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
      <title>Session Snippets</title>
    </head>
    <body>
       <h3>SessionStateItemCollection Snippets</h3>
    </body>
</html>
