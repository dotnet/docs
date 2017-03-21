
            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnet");
            // Get the section.
            AuthenticationSection authenticationSection = 
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");
            // Get the users collection.
            FormsAuthenticationUserCollection formsAuthenticationUsers =
                authenticationSection.Forms.Credentials.Users;
