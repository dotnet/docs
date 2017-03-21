
            // Get the Web application configuration.
            Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the section.
            CustomErrorsSection customErrors =
                (CustomErrorsSection)configuration.GetSection(
              "system.web/customErrors");

            // Get the collection.
            CustomErrorCollection customErrorsCollection =
                customErrors.Errors;
