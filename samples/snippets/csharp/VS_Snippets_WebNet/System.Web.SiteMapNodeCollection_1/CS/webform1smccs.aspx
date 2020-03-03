<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<Script runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
// <Snippet1>
    SiteMapNodeCollection siteNodes = SiteMap.RootNode.GetAllNodes();

    if ( siteNodes.IsReadOnly ||
         siteNodes.IsFixedSize )
    {
        Response.Write("Collection is read-only or has fixed size.<BR>");

        // Create a new, modifiable collection from the existing one.
        SiteMapNodeCollection modifiableCollection =
             new SiteMapNodeCollection(siteNodes);

        // The MoveNode example method moves a node from position one to
        // the last position in the collection.
        MoveNode(modifiableCollection);
    }
    else {
        MoveNode(siteNodes);
    }

// </Snippet1>
}
private void MoveNode (SiteMapNodeCollection nodes)
{
// <Snippet2>

    // Move a node from one spot in the list to another.
    try {
        Response.Write("Original node order: <BR>");
        foreach (SiteMapNode node in nodes) {
            Response.Write( node.Title + "<BR>");
        }
        SiteMapNode aNode = nodes[1];

        Response.Write("Adding " + aNode.Title + " to the end of the collection.<BR>");
        nodes.Add(aNode);

        Response.Write("Removing " + aNode.Title + " at position 1. <BR>");
        nodes.Remove(nodes[1]);

        Response.Write("New node order: <BR>");
        foreach (SiteMapNode node in nodes) {
            Response.Write( node.Title + "<BR>");
        }
    }
    catch (NotSupportedException nse) {
        Response.Write("NotSupportedException caught.<BR>");
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
