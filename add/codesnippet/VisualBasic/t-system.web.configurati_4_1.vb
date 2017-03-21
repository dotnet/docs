      ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the section. 
        Dim httpModulesSection As HttpModulesSection = _
        CType(configuration.GetSection( _
        "system.web/httpModules"), HttpModulesSection)
      