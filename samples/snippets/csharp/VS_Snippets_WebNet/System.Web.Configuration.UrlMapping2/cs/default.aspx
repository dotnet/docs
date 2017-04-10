<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    int showVal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the parameter value from the QueryString
        if (Request.Params["show"] != null)
            showVal = Int32.Parse(Request.Params["show"]);

        // Show a page depending on the parameter value
        NoShowPanel.Visible = (showVal == 0);
        ShowHomePage.Visible = (showVal == 1);
        ShowProductsPage.Visible = (showVal == 2);
        ShowEventsPage.Visible = (showVal == 3);

        // <Snippet2>
        UrlMapping urlMap = null;
        
        // Open Web.config
        Configuration config =
            WebConfigurationManager.OpenWebConfiguration("~");
        // Get the UrlMappings section
        UrlMappingsSection urlMapSection =
            (UrlMappingsSection)config.GetSection(
                "system.web/urlMappings");
        
        // Modify UrlMapping in Web.config first time through
        if (!Page.IsPostBack)
        {
            // If not already added, add a UrlMapping to the section
            if (urlMapSection.UrlMappings.Count == 2)
            {
                urlMap = new UrlMapping("~/events.aspx", 
                    "~/default.aspx?show=3");
                urlMapSection.UrlMappings.Add(urlMap);
                
                // This line assumes permission to write to disk
                config.Save();
            }
        }

        if (showVal > 0)
        {
            // <Snippet4>
            urlMap = (UrlMapping)urlMapSection.UrlMappings[showVal - 1];
            realURL.Text = urlMap.MappedUrl;
            // </Snippet4>
        }
        // </Snippet2>
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>UrlMapping Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Panel ID="NoShowPanel" runat="server" Visible="true">
        <h2>Show no page</h2>
        <p><a href="home.aspx">Home.aspx</a></p>
        <p><a href="products.aspx">Products.aspx</a></p>
        <p><a href="events.aspx">Events.aspx</a></p>
    </asp:Panel>
    <asp:Panel ID="ShowHomePage" runat="server" Visible="false">
        <h2>Home Page</h2>
        <p><a href="products.aspx">Products.aspx</a></p>
        <p><a href="events.aspx">Events.aspx</a></p>
    </asp:Panel>
    <asp:Panel ID="ShowProductsPage" runat="server" Visible="false">
        <h2>Products Page</h2>
        <p><a href="home.aspx">Home.aspx</a></p>
        <p><a href="events.aspx">Events.aspx</a></p>
    </asp:Panel>
    <asp:Panel ID="ShowEventsPage" runat="server" Visible="false">
        <h2>Events Page</h2>
        <p><a href="home.aspx">Home.aspx</a></p>
        <p><a href="products.aspx">Products.aspx</a></p>
    </asp:Panel>
    <p>The real URL for this page is 
        <asp:Label ID="realURL" runat="server">[None]</asp:Label></p>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
