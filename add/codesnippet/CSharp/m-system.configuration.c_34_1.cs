    // Create the AppSettings section.
    // The function uses the GetSection(string)method 
    // to access the configuration section. 
    // It also adds a new element to the section collection.
    public static void CreateAppSettings()
    {
      // Get the application configuration file.
      System.Configuration.Configuration config =
        ConfigurationManager.OpenExeConfiguration(
              ConfigurationUserLevel.None);

      string sectionName = "appSettings";

      // Add an entry to appSettings.
      int appStgCnt =
          ConfigurationManager.AppSettings.Count;
      string newKey = "NewKey" + appStgCnt.ToString();

      string newValue = DateTime.Now.ToLongDateString() + 
        " " + DateTime.Now.ToLongTimeString();

      config.AppSettings.Settings.Add(newKey, newValue);

      // Save the configuration file.
      config.Save(ConfigurationSaveMode.Modified);
      
      // Force a reload of the changed section. This 
      // makes the new values available for reading.
      ConfigurationManager.RefreshSection(sectionName);

      // Get the AppSettings section.
      AppSettingsSection appSettingSection =
        (AppSettingsSection)config.GetSection(sectionName);

      Console.WriteLine();
      Console.WriteLine("Using GetSection(string).");
      Console.WriteLine("AppSettings section:");
      Console.WriteLine(
        appSettingSection.SectionInformation.GetRawXml());
    }