        // Execute the Add method.
        System.Web.Configuration.OutputCacheProfile outputCacheProfile0 =
          new System.Web.Configuration.OutputCacheProfile("MyCacheProfile");
        outputCacheProfile0.Location = 
            System.Web.UI.OutputCacheLocation.Any;
        outputCacheProfile0.NoStore = false;

        outputCacheProfiles.Add(outputCacheProfile0);

        // Update if not locked.
        if (!outputCacheSettings.IsReadOnly())
        {
            webConfig.Save();
        }