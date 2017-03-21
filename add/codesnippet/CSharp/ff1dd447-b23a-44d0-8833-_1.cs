
    // Show how to create an instance of the Configuration class
    // that represents this application configuration file.  
    static void CreateConfigurationFile()
    {
        try
        {

            // Create a custom configuration section.
            CustomSection customSection = new CustomSection();

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Create the custom section entry  
            // in <configSections> group and the 
            // related target section in <configuration>.
            if (config.Sections["CustomSection"] == null)
            {
                config.Sections.Add("CustomSection", customSection);
            }

            // Create and add an entry to appSettings section.
            
            string conStringname="LocalSqlServer";
            string conString = @"data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true";
            string providerName="System.Data.SqlClient";

            ConnectionStringSettings connStrSettings = new ConnectionStringSettings();
            connStrSettings.Name = conStringname;
            connStrSettings.ConnectionString= conString;
            connStrSettings.ProviderName = providerName;

            config.ConnectionStrings.ConnectionStrings.Add(connStrSettings);
            
            // Add an entry to appSettings section.
            int appStgCnt =
                ConfigurationManager.AppSettings.Count;
            string newKey = "NewKey" + appStgCnt.ToString();

            string newValue = DateTime.Now.ToLongDateString() +
              " " + DateTime.Now.ToLongTimeString();

            config.AppSettings.Settings.Add(newKey, newValue);

            // Save the configuration file.
            customSection.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);

            Console.WriteLine("Created configuration file: {0}",
                config.FilePath);

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("CreateConfigurationFile: {0}", err.ToString());
        }

    }