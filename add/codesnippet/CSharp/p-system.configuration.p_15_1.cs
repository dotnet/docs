        static void GetDefaultProvider()
        {
            try
            {
                // Get the application configuration.
                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the protected configuration section.
                ProtectedConfigurationSection pcSection =
                    (System.Configuration.ProtectedConfigurationSection)
                    config.GetSection("configProtectedData");

                // Get the current DefaultProvider.
                Console.WriteLine(
                    "Protected configuration section default provider:");
                Console.WriteLine("  {0}", pcSection.DefaultProvider);

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine(e.ToString());
            }

        }