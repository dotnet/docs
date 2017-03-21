            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

            // Get the external Authentication section.
            AuthenticationSection authenticationSection = 
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");

            // Get the external Forms section .
            FormsAuthenticationConfiguration formsAuthentication =
                authenticationSection.Forms;
