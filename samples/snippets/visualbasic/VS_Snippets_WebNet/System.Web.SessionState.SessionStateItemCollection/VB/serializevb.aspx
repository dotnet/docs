<%@ Page Language="VB" %>
<%@ Import Namespace="System.Configuration" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%

'<Snippet3>
Dim items As SessionStateItemCollection = New SessionStateItemCollection()

items("LastName") = "Wilson"
items("FirstName") = "Dan"

Dim writer As System.IO.BinaryWriter = New System.IO.BinaryWriter( _
  System.IO.File.Open(Server.MapPath("session_collection.bin"), System.IO.FileMode.Create))

items.Serialize(writer)

writer.Close()
'</Snippet3>

'<Snippet4>
Dim reader As System.IO.BinaryReader = New System.IO.BinaryReader( _
  System.IO.File.Open(Server.MapPath("session_collection.bin"), System.IO.FileMode.Open))

Dim sessionItems As SessionStateItemCollection = SessionStateItemCollection.Deserialize(reader)

For I As Integer = 0 To sessionItems.Count - 1
  Response.Write("sessionItems(" & i & ") = " & sessionItems(i).ToString() & "<br />")
Next
'</Snippet4>

%>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Session Snippets</title>
    </head>
    <body>
        <h3>SessionStateItemCollection Snippets</h3>
    </body>
</html>
