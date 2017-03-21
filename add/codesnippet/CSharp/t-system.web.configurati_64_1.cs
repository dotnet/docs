            // Get the applicaqtion configuration.
            Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
               "/aspnetTest");

            // Get the section.
            AnonymousIdentificationSection anonymousIdentificationSection = 
                (AnonymousIdentificationSection)configuration.GetSection(
                "system.web/anonymousIdentification");