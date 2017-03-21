        static void GetItems()
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
                // with the specified index.
                ConnectionStringSettings cs =
                    csCollection[0];

                Console.WriteLine(
                     "cs: {0}", cs.Name);

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }