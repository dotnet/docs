
            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the section.
            CustomErrorsSection customErrorsSection =
              (CustomErrorsSection)configuration.GetSection(
              "system.web/customErrors");

            // Get the collection
            CustomErrorCollection customErrorsCollection = 
                customErrorsSection.Errors;
