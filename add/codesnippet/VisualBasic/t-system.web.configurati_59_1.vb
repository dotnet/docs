      ' Get the Web application configuration.
        Dim webConfig As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      
      ' Get the section.
        Dim configPath As String = _
        "system.web/cache/sqlCacheDependency"
        Dim sqlDs _
        As System.Web.Configuration.SqlCacheDependencySection = _
        CType(webConfig.GetSection(configPath), _
        System.Web.Configuration.SqlCacheDependencySection)
