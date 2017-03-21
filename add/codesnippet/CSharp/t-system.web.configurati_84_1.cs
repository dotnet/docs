
            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the <sessionPageState> section.
            SessionPageStateSection sessionPageState =
              (SessionPageStateSection)configuration.GetSection(
              "system.web/sessionPageState");
