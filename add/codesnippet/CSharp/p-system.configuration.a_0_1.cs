    // This function shows how to read the key/value
    // pairs (settings collection)contained in the 
    // appSettings section.
    static void ReadAppSettings()
	{
        try
        {

            // Get the configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Get the appSettings section.
            System.Configuration.AppSettingsSection appSettings =
                (System.Configuration.AppSettingsSection)config.GetSection("appSettings");

            // Get the auxiliary file name.
            Console.WriteLine("Auxiliary file: {0}", config.AppSettings.File);

            
            // Get the settings collection (key/value pairs).
            if (appSettings.Settings.Count != 0)
            {
                foreach (string key in appSettings.Settings.AllKeys)
                {
                    string value = appSettings.Settings[key].Value;
                    Console.WriteLine("Key: {0} Value: {1}", key, value);
                }
            }
            else
                Console.WriteLine("The appSettings section is empty. Write first.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception raised: {0}",
                e.Message);
        }
	}