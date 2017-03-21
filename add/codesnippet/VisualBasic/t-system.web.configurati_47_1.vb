      ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the section.
        Dim customErrors As CustomErrorsSection = _
         CType(configuration.GetSection( _
         "system.web/customErrors"), CustomErrorsSection)
      
      ' Get the collection.
        Dim customErrorsCollection _
        As CustomErrorCollection = _
        customErrors.Errors
      