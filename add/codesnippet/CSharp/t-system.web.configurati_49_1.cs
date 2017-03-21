
// Get the configuration.
// Get the Web application configuration.
System.Configuration.Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

// Get the section.
System.Web.Configuration.AuthenticationSection authenticationSection = (System.Web.Configuration.AuthenticationSection)configuration.GetSection("system.web/authentication");

// Get the authentication passport element.
PassportAuthentication passport = authenticationSection.Passport;
