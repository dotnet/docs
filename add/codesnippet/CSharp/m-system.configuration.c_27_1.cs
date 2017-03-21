    // Access the machine configuration file using mapping.
    // The function uses the OpenMappedMachineConfiguration 
    // method to access the machine configuration. 
    public static void MapMachineConfiguration()
    {
      // Get the machine.config file.
      Configuration machineConfig =
        ConfigurationManager.OpenMachineConfiguration();
      // Get the machine.config file path.
      ConfigurationFileMap configFile =
        new ConfigurationFileMap(machineConfig.FilePath);

      // Map the application configuration file to the machine 
      // configuration file.
      Configuration config =
        ConfigurationManager.OpenMappedMachineConfiguration(
          configFile);

      // Get the AppSettings section.
      AppSettingsSection appSettingSection =
        (AppSettingsSection)config.GetSection("appSettings");
      appSettingSection.SectionInformation.AllowExeDefinition =
          ConfigurationAllowExeDefinition.MachineToRoamingUser;

      // Display the configuration file sections.
      ConfigurationSectionCollection sections = 
        config.Sections;

      Console.WriteLine();
      Console.WriteLine("Using OpenMappedMachineConfiguration.");
      Console.WriteLine("Sections in machine.config:");

      // Get the sections in the machine.config.
      foreach (ConfigurationSection section in sections)
      {
          string name = section.SectionInformation.Name;
          Console.WriteLine("Name: {0}", name);
      }

    }
 