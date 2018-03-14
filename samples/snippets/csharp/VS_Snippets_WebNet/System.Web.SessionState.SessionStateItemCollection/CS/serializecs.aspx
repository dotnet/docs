<%@ Page Language="C#" %>
<%@ Import Namespace="System.Configuration" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%

//<Snippet3>
SessionStateItemCollection items = new SessionStateItemCollection();

items["LastName"] = "Wilson";
items["FirstName"] = "Dan";

System.IO.BinaryWriter writer = new System.IO.BinaryWriter(
  System.IO.File.Open(Server.MapPath("session_collection.bin"), System.IO.FileMode.Create));

items.Serialize(writer);

writer.Close();
//</Snippet3>

//<Snippet4>
System.IO.BinaryReader reader = new System.IO.BinaryReader(
  System.IO.File.Open(Server.MapPath("session_collection.bin"), System.IO.FileMode.Open));

SessionStateItemCollection sessionItems = SessionStateItemCollection.Deserialize(reader);

for (int i = 0; i < sessionItems.Count; i++)
  Response.Write("sessionItems[" + i + "] = " + sessionItems[i].ToString() + "<br />");
//</Snippet4>

%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Session Snippets</title>
</head>
<body>
<h3>SessionStateItemCollection Snippets</h3>
</body>
</html>
