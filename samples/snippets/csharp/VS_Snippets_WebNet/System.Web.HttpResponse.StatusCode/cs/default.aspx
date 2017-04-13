<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    // <Snippet1>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Show success or failure of page load.
        if (Response.StatusCode != 200)
        {
            Response.Write("There was a problem accessing the web resource" +
                "<br />" + Response.StatusDescription);
        }
    }
    // </Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Page For HttpResponse.StatusCode</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
