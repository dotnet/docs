' Get the Web application configuration.
Dim configuration As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

' Get the HttpModulesSection.
Dim httpModulesSection As HttpModulesSection = CType(configuration.GetSection("system.web/httpModules"), HttpModulesSection)
