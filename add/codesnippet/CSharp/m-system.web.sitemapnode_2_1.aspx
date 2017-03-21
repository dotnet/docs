
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