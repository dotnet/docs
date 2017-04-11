<%@ Page Language="C#" %>
<%@ Import Namespace="System.Configuration" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%
//<Snippet1>
SessionStateItemCollection items = new SessionStateItemCollection();

items["LastName"] = "Wilson";
items["FirstName"] = "Dan";

foreach (string s in items.Keys)
  Response.Write("items[\"" + s + "\"] = " + items[s].ToString() + "<br />");
//</Snippet1>

//<Snippet2>
SessionStateItemCollection sessionItems = new SessionStateItemCollection();

sessionItems["ZipCode"] = "98072";
sessionItems["Email"] = "someone@example.com";

for (int i = 0; i < items.Count; i++)
  Response.Write("sessionItems[" + i + "] = " + sessionItems[i].ToString() + "<br />");
//</Snippet2>

%>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Session Snippets</title>
</head>
<body>
<h3>SessionStateItemCollection Snippets</h3>
</body>
</html>
