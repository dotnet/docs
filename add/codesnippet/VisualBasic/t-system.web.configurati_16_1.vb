    ' Get the Web application configuration.
    Dim configuration As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest")
                
    ' Get the section.
    Dim httpHandlersSection As System.Web.Configuration.HttpHandlersSection = CType(configuration.GetSection("system.web/httphandlers"), System.Web.Configuration.HttpHandlersSection)
