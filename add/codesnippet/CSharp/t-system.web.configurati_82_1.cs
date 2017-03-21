
            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the <caching> section group.
            SystemWebCachingSectionGroup cachingSectionGroup =
              (SystemWebCachingSectionGroup)configuration.GetSectionGroup(
              "system.web/caching");
