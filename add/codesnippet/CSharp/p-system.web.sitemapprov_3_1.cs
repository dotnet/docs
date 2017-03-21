    // Implement the ParentProvider property.
    public override SiteMapProvider ParentProvider
    {
      get
      {
        return parentSiteMapProvider;
      }
      set
      {
        parentSiteMapProvider = value;
      }
    }

    // Implement the RootProvider property.
    public override SiteMapProvider RootProvider
    {
      get
      {
        // If the current instance belongs to a provider hierarchy, it
        // cannot be the RootProvider. Rely on the ParentProvider.
        if (this.ParentProvider != null)
        {
          return ParentProvider.RootProvider;
        }
        // If the current instance does not have a ParentProvider, it is
        // not a child in a hierarchy, and can be the RootProvider.
        else
        {
          return this;
        }
      }
    }