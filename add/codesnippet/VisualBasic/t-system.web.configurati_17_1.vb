      ' Get the Web application configuration.
        Dim webConfig _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration("/aspnetTest")
      
      ' Get the section.
        Dim configPath As String = _
        "system.web/cache/sqlCacheDependency"
        Dim sqlDs _
        As System.Web.Configuration.SqlCacheDependencySection = _
        CType(webConfig.GetSection(configPath), System.Web.Configuration.SqlCacheDependencySection)
      
      ' Get the databases element at 0 index.
        Dim sqlCdd _
        As System.Web.Configuration.SqlCacheDependencyDatabase = _
        sqlDs.Databases(0)
      