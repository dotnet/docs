<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<Script runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
    Response.Write( "Current Site Map.<BR><HR><BR>");
    Response.Write( SiteMap.RootNode.Title + "<BR>");
    foreach (SiteMapNode node in SiteMap.RootNode.GetAllNodes()) {
        Response.Write( node.Title + "<BR>");
    }
// <Snippet2>

    // Create a SiteMapNodeCollection with all the nodes
    // from the first two hierarchical levels of the current
    // site map.
    SiteMapNodeCollection baseCollection =
        new SiteMapNodeCollection(SiteMap.RootNode);

    SiteMapNodeCollection childCollection =
        SiteMap.RootNode.ChildNodes;

    baseCollection.AddRange(childCollection);

    Response.Write( "<BR>Derived SiteMapNodeCollection.<BR><HR><BR>");
    foreach (SiteMapNode node in baseCollection) {
        Response.Write( node.Title + "<BR>");
    }
// </Snippet2>
}
</Script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
