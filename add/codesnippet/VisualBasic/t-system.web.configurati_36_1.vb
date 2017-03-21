      ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the external Authentication section.
        Dim authenticationSection _
        As AuthenticationSection = _
        CType(configuration.GetSection( _
        "system.web/authentication"), AuthenticationSection)
      
      ' Get the external Forms section .
        Dim formsAuthentication _
        As FormsAuthenticationConfiguration = _
        authenticationSection.Forms
      