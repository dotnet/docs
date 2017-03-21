    public override CacheDependency GetCacheDependency(
      string virtualPath, 
      System.Collections.IEnumerable virtualPathDependencies, 
      DateTime utcStart)
    {
      if (IsPathVirtual(virtualPath))
      {
        System.Collections.Specialized.StringCollection fullPathDependencies = null;

        // Get the full path to all dependencies.
        foreach (string virtualDependency in virtualPathDependencies)
        {
          if (fullPathDependencies == null)
            fullPathDependencies = new System.Collections.Specialized.StringCollection();

          fullPathDependencies.Add(virtualDependency);
        }
        if (fullPathDependencies == null)
          return null;

        // Copy the list of full-path dependencies into an array.
        string[] fullPathDependenciesArray = new string[fullPathDependencies.Count];
        fullPathDependencies.CopyTo(fullPathDependenciesArray, 0);
        // Copy the virtual path into an array.
        string[] virtualPathArray = new string[1];
        virtualPathArray[0] = virtualPath;

        return new CacheDependency(virtualPathArray, fullPathDependenciesArray, utcStart);
      }
      else
        return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
    }