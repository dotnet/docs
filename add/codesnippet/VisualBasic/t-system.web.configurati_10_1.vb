      ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the authentication section.
        Dim authenticationSection _
        As AuthenticationSection = _
        CType(configuration.GetSection( _
        "system.web/authentication"), AuthenticationSection)
      
      ' Get the forms credentials collection .
        Dim formsAuthenticationCredentials _
        As FormsAuthenticationCredentials = _
        authenticationSection.Forms.Credentials
      