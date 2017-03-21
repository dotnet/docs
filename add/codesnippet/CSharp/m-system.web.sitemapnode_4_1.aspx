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
