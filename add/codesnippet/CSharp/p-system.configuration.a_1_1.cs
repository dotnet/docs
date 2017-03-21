    // This function shows how to use the File property of the
    // appSettings section.
    // The File property is used to specify an auxiliary 
    // configuration file.
    // Usually you create an auxiliary file off-line to store 
    // additional settings that you can modify as needed without
    // causing an application restart,as in the case of a Web 
    // application.
    // These settings are then added to the ones defined in the
    // application configuration file.
    static void  IntializeConfigurationFile()
    {
        // Create a set of unique key/value pairs to store in
        // the appSettings section of an auxiliary configuration
        // file.
        string time1 = String.Concat(DateTime.Now.ToLongDateString(),
                               " ", DateTime.Now.ToLongTimeString());

        string time2 = String.Concat(DateTime.Now.ToLongDateString(),
                               " ", new DateTime(2009, 06, 30).ToLongTimeString());
       
        string[] buffer = {"<appSettings>",
        "<add key='AuxAppStg0' value='" + time1 + "'/>", 
        "<add key='AuxAppStg1' value='" + time2 + "'/>",
        "</appSettings>"};

        // Create an auxiliary configuration file and store the
        // appSettings defined before.
        // Note creating a file at run-time is just for demo 
        // purposes to run this example.
        File.WriteAllLines("auxiliaryFile.config", buffer);
        
        // Get the current configuration associated
        // with the application.
        System.Configuration.Configuration config =
           ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        // Associate the auxiliary with the default
        // configuration file. 
        System.Configuration.AppSettingsSection appSettings = config.AppSettings;
        appSettings.File = "auxiliaryFile.config";
        
        // Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified);

        // Force a reload in memory of the 
        // changed section.
        ConfigurationManager.RefreshSection("appSettings");

    }