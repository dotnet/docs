    // Implement the CurrentNode property.
    public override SiteMapNode CurrentNode
    {
      get
      {
        string currentUrl = FindCurrentUrl();
        // Find the SiteMapNode that represents the current page.
        SiteMapNode currentNode = FindSiteMapNode(currentUrl);
        return currentNode;
      }
    }

    // Implement the RootNode property.
    public override SiteMapNode RootNode
    {
      get
      {
        return rootNode;
      }
    }