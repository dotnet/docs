        ' Create a new BuildProvider.
        Dim myBuildProvider As BuildProvider = _
          New BuildProvider(".myres", _
          "System.Web.Compilation.ResourcesBuildProvider")

        ' Add an BuildProvider to the collection.
        configSection.BuildProviders.Add(myBuildProvider)