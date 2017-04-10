<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    private void Page_Load(object sender, EventArgs e)
    {
    // <snippet3>
        // Check whether the request is sent
        // over HTTPS. If not, do not send 
        // content to the client.    
        if (!Request.IsSecureConnection)
        {
            Response.SuppressContent = true;
        }
    // </snippet3>
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        This is a simple page to test the SuppressContent method.
    </form>
</body>
</html>
