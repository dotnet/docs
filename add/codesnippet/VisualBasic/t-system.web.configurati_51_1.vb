      ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnet")
      ' Get the section.
        Dim authenticationSection _
        As AuthenticationSection = _
        CType(configuration.GetSection( _
        "system.web/authentication"), AuthenticationSection)
      ' Get the users collection.
        Dim formsAuthenticationUsers _
        As FormsAuthenticationUserCollection = _
        authenticationSection.Forms.Credentials.Users
      