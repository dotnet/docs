<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
public void Page_Load()
{

//<Snippet9>
foreach (string s in Session.Contents)
  Response.Write(s + " = " + Session[s].ToString() + "<br />");
//</Snippet9>

//<Snippet10>
foreach (System.Collections.DictionaryEntry de in Session.StaticObjects)
  Response.Write(de.Key + " is of type " + de.Value.GetType().ToString() + "<br />");
//</Snippet10>

//<Snippet31>
bool readOnlySession = false;

if (Context.Handler is IReadOnlySessionState)
  readOnlySession = true;
//</Snippet31>
Response.Write("readOnlySession = " + readOnlySession + "<br />");

//<Snippet32>
bool requiresSession = false;

if (Context.Handler is IRequiresSessionState)
  requiresSession = true;
//</Snippet32>
Response.Write("requiresSession = " + requiresSession + "<br />");

}
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Session Contents</title>
</head>
<body>

<form id="form1" runat="server">

</form>

</body>
</html>
