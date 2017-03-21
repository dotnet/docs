        static void GetIndex()
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

                // Get its index;
                int index = csCollection.IndexOf(cs);

                Console.WriteLine(
                     "Connection string settings index: {0}", 
                     index.ToString());

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }