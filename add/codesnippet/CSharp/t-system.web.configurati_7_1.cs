    
      // Get the Web application configuration.
      System.Configuration.Configuration webConfig =
      WebConfigurationManager.OpenWebConfiguration("/aspnetTest");


      // Get the section.
      string configPath = "system.web/httpCookies";
      System.Web.Configuration.HttpCookiesSection httpCookiesSection =
      (System.Web.Configuration.HttpCookiesSection)webConfig.GetSection(
      configPath);
