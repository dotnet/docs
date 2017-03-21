
            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

            // Get the authentication section.
            AuthenticationSection authenticationSection = 
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");

            // Get the forms credentials collection .
            FormsAuthenticationCredentials formsAuthenticationCredentials =
                authenticationSection.Forms.Credentials;
