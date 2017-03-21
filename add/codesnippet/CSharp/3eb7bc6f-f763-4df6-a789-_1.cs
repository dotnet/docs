    // Get the roaming configuration file associated 
    // with the application.
    // This function uses the OpenExeConfiguration(
    // ConfigurationUserLevel userLevel) method to 
    // get the configuration file.
    // It also creates a custom ConsoleSection and 
    // sets its ConsoleEment BackgroundColor and
    // ForegroundColor properties to blue and yellow
    // respectively. Then it uses these properties to
    // set the console colors.  
    public static void GetRoamingConfiguration()
    {
      // Define the custom section to add to the
      // configuration file.
      string sectionName = "consoleSection";
      ConsoleSection currentSection = null;
      
      // Get the roaming configuration 
      // that applies to the current user.
      Configuration roamingConfig =
        ConfigurationManager.OpenExeConfiguration(
         ConfigurationUserLevel.PerUserRoaming);

      // Map the roaming configuration file. This
      // enables the application to access 
      // the configuration file using the
      // System.Configuration.Configuration class
      ExeConfigurationFileMap configFileMap =
        new ExeConfigurationFileMap();
      configFileMap.ExeConfigFilename = 
        roamingConfig.FilePath;

      // Get the mapped configuration file.
      Configuration config =
        ConfigurationManager.OpenMappedExeConfiguration(
          configFileMap, ConfigurationUserLevel.None);
      
      try
        {
          currentSection =
               (ConsoleSection)config.GetSection(
                 sectionName);

          // Synchronize the application configuration
          // if needed. The following two steps seem
          // to solve some out of synch issues 
          // between roaming and default
          // configuration.
          config.Save(ConfigurationSaveMode.Modified);

          // Force a reload of the changed section, 
          // if needed. This makes the new values available 
          // for reading.
          ConfigurationManager.RefreshSection(sectionName);

          if (currentSection == null)
          {
            // Create a custom configuration section.
            currentSection = new ConsoleSection();

            // Define where in the configuration file 
            // hierarchy the associated 
            // configuration section can be declared.
            // The following assignment assures that 
            // the configuration information can be 
            // defined in the user.config file in the 
            // roaming user directory. 
            currentSection.SectionInformation.AllowExeDefinition =
              ConfigurationAllowExeDefinition.MachineToLocalUser;

            // Allow the configuration section to be 
            // overridden by lower-level configuration files.
            // This means that lower-level files can contain
            // the section (use the same name) and assign 
            // different values to it as done by the
            // function GetApplicationConfiguration() in this
            // example.
            currentSection.SectionInformation.AllowOverride =
              true;

            // Store console settings for roaming users.
            currentSection.ConsoleElement.BackgroundColor =
                ConsoleColor.Blue;
            currentSection.ConsoleElement.ForegroundColor =
                ConsoleColor.Yellow;

            // Add configuration information to 
            // the configuration file.
            config.Sections.Add(sectionName, currentSection);
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(
              sectionName);
          }
      }
      catch (ConfigurationErrorsException e)
      {
          Console.WriteLine("[Exception error: {0}]",
              e.ToString());
      }

      // Set console properties using values
      // stored in the configuration file.
      Console.BackgroundColor =
        currentSection.ConsoleElement.BackgroundColor;
      Console.ForegroundColor =
        currentSection.ConsoleElement.ForegroundColor;
      // Apply the changes.
      Console.Clear();

      // Display feedback.
      Console.WriteLine();
      Console.WriteLine(
        "Using OpenExeConfiguration(ConfigurationUserLevel).");
      Console.WriteLine(
          "Configuration file is: {0}", config.FilePath);
    }