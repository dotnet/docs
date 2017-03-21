            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the section.
            AuthenticationSection authenticationSection =
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");
