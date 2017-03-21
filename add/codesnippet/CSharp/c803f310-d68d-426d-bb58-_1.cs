        static void RemoveConnectionStrings()
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

                // Get the connection string setting element
                // with the specified name.
                ConnectionStringSettings cs =
                    csCollection["ConnStr0"];

                // Remove it.
                if (cs != null)
                {
                    // Remove the element.
                    csCollection.Remove(cs);

                    // Save the configuration file.
                    config.Save(ConfigurationSaveMode.Modified);
                    
                    Console.WriteLine(
                     "Connection string settings removed.");
                }
                else
                    Console.WriteLine(
                        "Connection string settings does not exist.");

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }