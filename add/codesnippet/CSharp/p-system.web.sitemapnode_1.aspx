
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