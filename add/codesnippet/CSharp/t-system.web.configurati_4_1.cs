
            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

            // Get the section. 
            HttpModulesSection httpModulesSection = 
                (HttpModulesSection) configuration.GetSection(
                "system.web/httpModules");
