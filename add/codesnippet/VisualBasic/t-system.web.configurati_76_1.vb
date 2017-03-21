' Get the Web application configuration.
Dim configuration As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

' Get the section.
Dim identitySection As System.Web.Configuration.IdentitySection = CType(configuration.GetSection("system.web/identity"), System.Web.Configuration.IdentitySection)
