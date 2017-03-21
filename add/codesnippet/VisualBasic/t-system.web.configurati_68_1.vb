      ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the section.
        Dim authenticationSection _
        As AuthenticationSection = _
        CType(configuration.GetSection( _
        "system.web/authentication"), AuthenticationSection)
      