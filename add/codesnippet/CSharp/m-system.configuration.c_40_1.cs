        static void RemoveConnectionStrings3()
        {

            try
            {
                System.Configuration.Configuration config =
                 ConfigurationManager.OpenExeConfiguration(
                 ConfigurationUserLevel.None);

                // Clear the connection strings collection.
                ConnectionStringsSection csSection =
                    config.ConnectionStrings;
                ConnectionStringSettingsCollection csCollection =
                 csSection.ConnectionStrings;

                // Remove the element.
                csCollection.RemoveAt(0);

                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified);
                
                Console.WriteLine(
                     "Connection string settings removed.");
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }