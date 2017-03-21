 
// Get the Web application configuration.
Configuration configuration = WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

// Get the HttpModulesSection.
HttpModulesSection httpModulesSection = (HttpModulesSection) configuration.GetSection("system.web/httpModules");
