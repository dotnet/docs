        // Get the Web application configuration object.
        System.Configuration.Configuration configuration =
          System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

        // Get the section related object.
        System.Web.Configuration.SessionStateSection sessionStateSection =
          (System.Web.Configuration.SessionStateSection)
          configuration.GetSection("system.web/sessionState");