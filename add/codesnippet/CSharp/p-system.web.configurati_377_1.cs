            // Get the configuration file. Replace the name configTarget
            // with the name of your site.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration("/configTarget");


            // Get the external Authentication section.
            AuthenticationSection authenticationSection =
                (AuthenticationSection)configuration.GetSection(
                "system.web/authentication");

            // Get the external Forms section .
            FormsAuthenticationConfiguration formsAuthentication =
              authenticationSection.Forms;

            string cookieName = formsAuthentication.Name;