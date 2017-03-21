        // Get the Web application configuration.
        Configuration webConfig = 
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest");
                
        // Get the section.
        string configPath = "system.web/cache/sqlCacheDependency";
        SqlCacheDependencySection sqlCacheDependencySection =
          (SqlCacheDependencySection)webConfig.GetSection(configPath);

        // Get the database element at the specified index.
        SqlCacheDependencyDatabaseCollection sqlCdds =
            sqlCacheDependencySection.Databases;
