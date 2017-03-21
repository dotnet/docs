        // Create a connectionn string element and add it to
        // the connection strings section.
        static ConnectionStrings()
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the current connection strings count.
            int connStrCnt = 
                ConfigurationManager.ConnectionStrings.Count;
 
            // Create the connection string name. 
            string csName = 
                "ConnStr" + connStrCnt.ToString();

            // Create a connection string element and
            // save it to the configuration file.
           
            // Create a connection string element.
            ConnectionStringSettings csSettings =
                    new ConnectionStringSettings(csName,
                    "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" +
                    "Initial Catalog=aspnetdb", "System.Data.SqlClient");

            // Get the connection strings section.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;

            // Add the new element.
            csSection.ConnectionStrings.Add(csSettings);
                
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);
            
        }