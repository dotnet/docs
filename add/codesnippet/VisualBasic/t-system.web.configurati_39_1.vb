        '  ' Get the Web application configuration.
        Dim webConfig _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the section.
        Dim configPath As String = _
       "system.web/caching/outputCacheSettings"
        Dim outputCacheSettings _
        As System.Web.Configuration.OutputCacheSettingsSection = _
        CType(webConfig.GetSection(configPath), _
        System.Web.Configuration.OutputCacheSettingsSection)
      
      ' Get the profile collection.
        Dim outputCacheProfiles _
        As System.Web.Configuration.OutputCacheProfileCollection = _
        outputCacheSettings.OutputCacheProfiles
      