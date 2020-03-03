<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:SiteMapDataSource
                id="SiteMapDataSource1"
                runat="server"
                StartingNodeUrl="WebForm1.aspx">
            </asp:SiteMapDataSource>

            <asp:TreeView
                id="TreeView1"
                runat="server"
                DataSourceID="SiteMapDataSource1">
            </asp:TreeView>

        </form>
    </body>
</html>
<!-- </Snippet1> -->