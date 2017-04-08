<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Dim showVal As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the parameter value from the QueryString
        If Not IsNothing(Request.Params("show")) Then
            showVal = Int32.Parse(Request.Params("show"))
        Else
            showVal = 0
        End If
        
        ' Show a page depending on the parameter value
        NoShowPanel.Visible = (showVal = 0)
        ShowHomePage.Visible = (showVal = 1)
        ShowProductsPage.Visible = (showVal = 2)
        ShowEventsPage.Visible = (showVal = 3)

        ' <Snippet2>
         dim urlMap as UrlMapping

        Dim config As Configuration
        ' Open Web.config
        config = _
            WebConfigurationManager.OpenWebConfiguration("~")
        ' Get the UrlMappings section
        Dim urlMapSection As UrlMappingsSection
        urlMapSection = _
           CType(config.GetSection( _
               "system.web/urlMappings"), UrlMappingsSection)
               
        ' Modify UrlMapping in Web.config first time through
        If (Not Page.IsPostBack) Then
            ' If not already added, add a UrlMapping to the section
            If urlMapSection.UrlMappings.Count = 2 Then
                urlMap = New UrlMapping("~/events.aspx", _
                    "~/default.aspx?show=3")
                urlMapSection.UrlMappings.Add(urlMap)
                
                ' This line assumes permission to write to disk
                config.Save()
            End If
        End If
        
        If showVal > 0 Then
            '<Snippet4>
            urlMap = CType(urlMapSection.UrlMappings(showVal - 1), UrlMapping)
            realURL.Text = urlMap.MappedUrl
            '</Snippet4>
        End If
        ' </Snippet2>
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
        <asp:Label ID="realURL" runat="server">default.aspx</asp:Label></p>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
