        static void GetProviderCollection()
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

                Console.WriteLine(
               "Protected configuration section providers:");
                foreach (ProviderSettings ps in
                pcSection.Providers)
                {
                    Console.WriteLine("  {0}", ps.Name);
                }

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine(e.ToString());
            }

        }