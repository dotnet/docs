<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    ' <Snippet1>
    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)
        Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
        Server.Execute("Login.aspx", writer, True)
        Response.Write("<h3>Please Login:</h3><br />" + writer.ToString())
    End Sub
    '</Snippet1>
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
