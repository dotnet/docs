// Get the Web application configuration.
System.Configuration.Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

// Get the section.
System.Web.Configuration.IdentitySection identitySection = (System.Web.Configuration.IdentitySection)configuration.GetSection("system.web/identity");