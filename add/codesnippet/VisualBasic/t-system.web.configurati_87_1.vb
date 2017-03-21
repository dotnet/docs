         ' Get the Web application configuration
            Dim configuration _
            As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")
         
         ' Get the section.
            Dim processModelSection _
            As System.Web.Configuration.ProcessModelSection = _
            CType(configuration.GetSection( _
            "system.web/processModel"), ProcessModelSection)
         