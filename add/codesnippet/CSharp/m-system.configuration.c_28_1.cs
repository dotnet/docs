    // Get the application configuration file.
    // This function uses the 
    // OpenExeConfiguration(string)method 
    // to get the application configuration file. 
    // It also creates a custom ConsoleSection and 
    // sets its ConsoleEment BackgroundColor and
    // ForegroundColor properties to black and white
    // respectively. Then it uses these properties to
    // set the console colors.  
    public static void GetAppConfiguration()
    {

      // Get the application path needed to obtain
      // the application configuration file.
#if DEBUG
      string applicationName =
          Environment.GetCommandLineArgs()[0];
#else
           string applicationName =
          Environment.GetCommandLineArgs()[0]+ ".exe";
#endif

      string exePath = System.IO.Path.Combine(
          Environment.CurrentDirectory, applicationName);

      // Get the configuration file. The file name has
      // this format appname.exe.config.
      System.Configuration.Configuration config =
        ConfigurationManager.OpenExeConfiguration(exePath);

      try
      {
        
        // Create a custom configuration section
        // having the same name that is used in the 
        // roaming configuration file.
        // This is because the configuration section 
        // can be overridden by lower-level 
        // configuration files. 
        // See the GetRoamingConfiguration() function in 
        // this example.
        string sectionName = "consoleSection";
        ConsoleSection customSection = new ConsoleSection();

        if (config.Sections[sectionName] == null)
        {
          // Create a custom section if it does 
          // not exist yet.
          
          // Store console settings.
          customSection.ConsoleElement.BackgroundColor =
              ConsoleColor.Black;
          customSection.ConsoleElement.ForegroundColor =
              ConsoleColor.White;

          // Add configuration information to the
          // configuration file.
          config.Sections.Add(sectionName, customSection);
          config.Save(ConfigurationSaveMode.Modified);
          // Force a reload of the changed section.
          // This makes the new values available for reading.
          ConfigurationManager.RefreshSection(sectionName);
        }
        // Set console properties using values
        // stored in the configuration file.
        customSection =
            (ConsoleSection)config.GetSection(sectionName);
        Console.BackgroundColor =
            customSection.ConsoleElement.BackgroundColor;
        Console.ForegroundColor =
            customSection.ConsoleElement.ForegroundColor;
        // Apply the changes.
        Console.Clear();
      }
      catch (ConfigurationErrorsException e)
      {
        Console.WriteLine("[Error exception: {0}]",
            e.ToString());
      }
     
      // Display feedback.
      Console.WriteLine();
      Console.WriteLine("Using OpenExeConfiguration(string).");
      // Display the current configuration file path.
      Console.WriteLine("Configuration file is: {0}", 
        config.FilePath);
    }