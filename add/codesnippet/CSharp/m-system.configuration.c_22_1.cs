        // Clear connection strings collection.
        static void ClearConnectionStrings()
        {

            // Get the configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

            // Clear the connection strings collection.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            csSection.ConnectionStrings.Clear();
           
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            Console.WriteLine("Connection strings cleared.");


        }