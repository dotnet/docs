
      // Get the Web application configuration.
      System.Configuration.Configuration configuration =
          WebConfigurationManager.OpenWebConfiguration(
          "/aspnetTest");

      // Get the <urlMapping> section.
      UrlMappingsSection urlMappingSection =
        (UrlMappingsSection)configuration.GetSection(
        "system.web/urlMappings");


      // Get the url mapping collection.
      UrlMappingCollection urlMappings =
        urlMappingSection.UrlMappings;

