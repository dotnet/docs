        // Get the Web application configuration.
        System.Configuration.Configuration webConfig = 
        WebConfigurationManager.OpenWebConfiguration("/aspnetTest");
                        

        // Get the section.
        string configPath = "system.web/cache/sqlCacheDependency";
        System.Web.Configuration.SqlCacheDependencySection sqlDs = 
        (System.Web.Configuration.SqlCacheDependencySection)webConfig.GetSection(
        configPath);

        