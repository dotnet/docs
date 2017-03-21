
            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the <system.web> group.
            SystemWebSectionGroup systemWeb =
              (SystemWebSectionGroup)configuration.GetSectionGroup("system.web");
