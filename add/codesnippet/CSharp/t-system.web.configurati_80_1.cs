
      // Get the Web application configuration.
      System.Configuration.Configuration configuration =
          WebConfigurationManager.OpenWebConfiguration(
          "/aspnetTest");

      // Get the <clientTarget> section.
      ClientTargetSection clientTargetSection =
        (ClientTargetSection)configuration.GetSection(
        "system.web/clientTarget");


      // Get the client target collection.
      ClientTargetCollection clientTargets =
        clientTargetSection.ClientTargets;

