
      // Get the current Location.
      System.Web.UI.OutputCacheLocation locationValue = 
          outputCacheProfile.Location;

      // Set the Location property to null.
      outputCacheProfile.Location = 
          System.Web.UI.OutputCacheLocation.Server;
