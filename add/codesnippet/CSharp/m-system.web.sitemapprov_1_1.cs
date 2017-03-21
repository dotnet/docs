    // Implement the FindSiteMapNode method.
    public override SiteMapNode FindSiteMapNode(string rawUrl)
    {

      // Does the root node match the URL?
      if (RootNode.Url == rawUrl)
      {
        return RootNode;
      }
      else
      {
        SiteMapNode candidate = null;
        // Retrieve the SiteMapNode that matches the URL.
        lock (this)
        {
          candidate = GetNode(siteMapNodes, rawUrl);
        }
        return candidate;
      }
    }