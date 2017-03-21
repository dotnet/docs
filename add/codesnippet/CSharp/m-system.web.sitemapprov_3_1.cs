    // Implement the GetChildNodes method.
    public override SiteMapNodeCollection GetChildNodes(SiteMapNode node)
    {
      SiteMapNodeCollection children = new SiteMapNodeCollection();
      // Iterate through the ArrayList and find all nodes that have the specified node as a parent.
      lock (this)
      {
        for (int i = 0; i < childParentRelationship.Count; i++)
        {

          string nodeUrl = ((DictionaryEntry)childParentRelationship[i]).Key as string;

          SiteMapNode parent = GetNode(childParentRelationship, nodeUrl);

          if (parent != null && node.Url == parent.Url)
          {
            // The SiteMapNode with the Url that corresponds to nodeUrl
            // is a child of the specified node. Get the SiteMapNode for
            // the nodeUrl.
            SiteMapNode child = FindSiteMapNode(nodeUrl);
            if (child != null)
            {
              children.Add(child as SiteMapNode);
            }
            else
            {
              throw new Exception("ArrayLists not in sync.");
            }
          }
        }
      }
      return children;
    }
    protected override SiteMapNode GetRootNodeCore()
    {
      return RootNode;
    }
    // Implement the GetParentNode method.
    public override SiteMapNode GetParentNode(SiteMapNode node)
    {
      // Check the childParentRelationship table and find the parent of the current node.
      // If there is no parent, the current node is the RootNode.
      SiteMapNode parent = null;
      lock (this)
      {
        // Get the Value of the node in childParentRelationship
        parent = GetNode(childParentRelationship, node.Url);
      }
      return parent;
    }