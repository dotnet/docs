<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
// <Snippet1>
private void Page_Load(Object sender, EventArgs e)
{
    System.IO.StringWriter writer = new System.IO.StringWriter();
    Server.Execute("Login.aspx", writer, true);
    Response.Write("<h3>Please Login:</h3><br />" + writer.ToString());
} 
// </Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
