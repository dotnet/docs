        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the section.
        Dim sessionStateSection As System.Web.Configuration.SessionStateSection = _
        CType(configuration.GetSection("system.web/sessionState"), _
          System.Web.Configuration.SessionStateSection)