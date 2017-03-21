        static void ShowConnectionStrings()
        {
             // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the conectionStrings section.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            
            for (int i = 0; i < 
                ConfigurationManager.ConnectionStrings.Count; i++)
            {
                ConnectionStringSettings cs = 
                    csSection.ConnectionStrings[i];
                
                Console.WriteLine("  Connection String: \"{0}\"",
                    cs.ConnectionString);

                Console.WriteLine("#{0}", i);
                Console.WriteLine("  Name: {0}", cs.Name);
             
                
                Console.WriteLine("  Provider Name: {0}", 
                    cs.ProviderName);
                
            }

        }