        ' Get the Web application configuration.
        Dim webConfig As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the section.
        Dim configPath As String = "system.web/sqlCacheDependency"
        Dim sqlCacheDependencySection As SqlCacheDependencySection = _
        CType(webConfig.GetSection(configPath), SqlCacheDependencySection)

        ' Get the database element at the specified index.
        Dim sqlCdds _
        As SqlCacheDependencyDatabaseCollection = _
            sqlCacheDependencySection.Databases
