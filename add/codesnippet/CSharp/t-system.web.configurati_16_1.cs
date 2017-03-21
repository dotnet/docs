
     // Get the Web application configuration.
     System.Configuration.Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest");
                
     // Get the section.
     System.Web.Configuration.HttpHandlersSection httpHandlersSection = (System.Web.Configuration.HttpHandlersSection) configuration.GetSection("system.web/httphandlers");

