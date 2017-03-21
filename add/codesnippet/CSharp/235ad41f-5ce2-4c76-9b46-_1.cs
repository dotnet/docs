        // Add a connection string to the connection
        // strings section and store it in the
        // configuration file.
        static void AddConnectionStrings()
        {
           
            // Get the count of the connection strings.
            int connStrCnt = 
                ConfigurationManager.ConnectionStrings.Count;
            
            // Define the string name.
            string csName = "ConnStr" + 
                connStrCnt.ToString();

            // Get the configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
            
            // Add the connection string.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            csSection.ConnectionStrings.Add(
                new ConnectionStringSettings(csName,
                    "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" +
                    "Initial Catalog=aspnetdb", "System.Data.SqlClient"));

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            Console.WriteLine("Connection string added.");

        }