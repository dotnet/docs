<!-- <Snippet2> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // Find the server name on the previous page
        TextBox txt = 
                (TextBox)Page.PreviousPage.FindControl("serverNameText");
        if (txt != null)
            prevServerName.Text = Server.HtmlEncode(txt.Text);
        else
            prevServerName.Text = "[Name Not available]";
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page A</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Database Server is Not Available</h2>

    <p>This page appears if the named database server is not 
    available, but the URL displays as the main target page.</p>
    
    <p>Server Name (From Page.PreviousPage): 
        <asp:Label ID="prevServerName" runat="server" /></p>
    
    <p>Refresh the page to see if the server is now available.</p>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
