' Get the configuration.
Dim configuration As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

' Get the authentication section.
Dim authenticationSection As System.Web.Configuration.AuthenticationSection = CType(configuration.GetSection("system.web/authentication"), System.Web.Configuration.AuthenticationSection)

' Get the authentication passport element.
Dim passport As PassportAuthentication = authenticationSection.Passport
