
                // Get the Web application configuration
                System.Configuration.Configuration configuration = 
                    WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

                // Get the section.
                System.Web.Configuration.ProcessModelSection 
                    processModelSection = 
                        (ProcessModelSection)configuration.GetSection(
                        "system.web/processModel");
