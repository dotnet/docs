        // Create a new BuildProvider.
        BuildProvider myBuildProvider =
          new BuildProvider(".myres",
          "System.Web.Compilation.ResourcesBuildProvider");

        // Add an BuildProvider to the collection.
        configSection.BuildProviders.Add(myBuildProvider);