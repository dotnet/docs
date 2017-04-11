<%--<snippet1>--%>
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    private void Page_Load(object sender, EventArgs e)
    {
        // Check whether the browser remains
        // connected to the server.
        if (Response.IsClientConnected)
        {
            // If still connected, redirect
            // to another page. 
            Response.Redirect("Page2CS.aspx", false);
        }
        else
        {
            // If the browser is not connected
            // stop all response processing.
            Response.End();
        }
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>
<%--</snippet1>--%>
