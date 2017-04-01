// <Snippet1>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

// The following example shows how to use the ConfigurationManager 
// class in a console application.
//
// IMPORTANT: To compile this example, you must add to the project 
// a reference to the System.Configuration assembly.
//
  #region RNAME1
  //*** Auxiliary Classes ***//

  // Define a custom configuration element to be 
  // contained by the ConsoleSection. This element 
  // stores background and foreground colors that
  // the application applies to the console window.
  public class ConsoleConfigElement : ConfigurationElement
  {
    // Create the element.
    public ConsoleConfigElement()
    { }
   
    // Create the element.
    public ConsoleConfigElement(ConsoleColor fColor, 
        ConsoleColor bColor)
    {
      ForegroundColor = fColor;
      BackgroundColor = bColor;
    }

    // Get or set the console background color.
    [ConfigurationProperty("background",
      DefaultValue = ConsoleColor.Black,
      IsRequired = false)]
    public ConsoleColor BackgroundColor
    {
      get
      {
        return (ConsoleColor)this["background"];
      }
      set
      {
        this["background"] = value;
      }
    }

    // Get or set the console foreground color.
    [ConfigurationProperty("foreground",
       DefaultValue = ConsoleColor.White,
       IsRequired = false)]
    public ConsoleColor ForegroundColor
    {
      get
      {
        return (ConsoleColor)this["foreground"];
      }
      set
      {
        this["foreground"] = value;
      }
    }
  }

  // Define a custom section that is used by the application
  // to create custom configuration sections at the specified 
  // level in the configuration hierarchy that is in the 
  // proper configuration file.
  // This enables the user that has the proper access 
  // rights, to make changes to the configuration files.
  public class ConsoleSection : ConfigurationSection
  {
    // Create a configuration section.
    public ConsoleSection()
    { }

    // Set or get the ConsoleElement. 
    [ConfigurationProperty("consoleElement")]
    public ConsoleConfigElement ConsoleElement
    {
      get
      {
        return (
          (ConsoleConfigElement) this["consoleElement"]);
      }
      set
      {
        this["consoleElement"] = value;
      }
    }
  }
  #endregion

  #region RNAME2
  //*** ConfigurationManager Interaction Class ***//

  // The following code uses the ConfigurationManager class to 
  // perform the following tasks:
  // 1) Get the application roaming configuration file.
  // 2) Get the application configuration file.
  // 3) Access a specified configuration file through mapping.
  // 4) Access the machine configuration file through mapping. 
  // 5) Read a specified configuration section.
  // 6) Read the connectionStrings section.
  // 7) Read or write the appSettings section.
  public static class UsingConfigurationManager
  {
    
    // <Snippet5>
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
    // </Snippet5>

    // <Snippet6>
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
    // </Snippet6>

    // <Snippet2>
    // Get the AppSettings section.        
    // This function uses the AppSettings property
    // to read the appSettings configuration 
    // section.
    public static void ReadAppSettings()
    {
      try
      {
        // Get the AppSettings section.
        NameValueCollection appSettings =
           ConfigurationManager.AppSettings;

        // Get the AppSettings section elements.
        Console.WriteLine();
        Console.WriteLine("Using AppSettings property.");
        Console.WriteLine("Application settings:");
       
        if (appSettings.Count == 0)
        {
          Console.WriteLine("[ReadAppSettings: {0}]",
          "AppSettings is empty Use GetSection command first.");
        }
        for (int i = 0; i < appSettings.Count; i++)
        {
          Console.WriteLine("#{0} Key: {1} Value: {2}",
            i, appSettings.GetKey(i), appSettings[i]);
        }
      }
      catch (ConfigurationErrorsException e)
      {
        Console.WriteLine("[ReadAppSettings: {0}]",
            e.ToString());
      }
    }
    // </Snippet2>

    // <Snippet3>
    // Get the ConnectionStrings section.        
    // This function uses the ConnectionStrings 
    // property to read the connectionStrings
    // configuration section.
    public static void ReadConnectionStrings()
    {

      // Get the ConnectionStrings collection.
      ConnectionStringSettingsCollection connections =
          ConfigurationManager.ConnectionStrings;

      if (connections.Count != 0)
      {
        Console.WriteLine();
        Console.WriteLine("Using ConnectionStrings property.");
        Console.WriteLine("Connection strings:");

        // Get the collection elements.
        foreach (ConnectionStringSettings connection in 
          connections)
        {
          string name = connection.Name;
          string provider = connection.ProviderName;
          string connectionString = connection.ConnectionString;

          Console.WriteLine("Name:               {0}", 
            name);
          Console.WriteLine("Connection string:  {0}", 
            connectionString);
         Console.WriteLine("Provider:            {0}", 
            provider);
        }
      }
      else
      {
        Console.WriteLine();
        Console.WriteLine("No connection string is defined.");
        Console.WriteLine();
      }
    }
    // </Snippet3>

    // <Snippet7>
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
    // </Snippet7>

    // <Snippet4>
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
 
  // </Snippet4>

  // <Snippet9>

    // Access a configuration file using mapping.
    // This function uses the OpenMappedExeConfiguration 
    // method to access a new configuration file.   
    // It also gets the custom ConsoleSection and 
    // sets its ConsoleEment BackgroundColor and
    // ForegroundColor properties to green and red
    // respectively. Then it uses these properties to
    // set the console colors.  
    public static void MapExeConfiguration()
    {

      // Get the application configuration file.
      System.Configuration.Configuration config =
        ConfigurationManager.OpenExeConfiguration(
              ConfigurationUserLevel.None);
    
      Console.WriteLine(config.FilePath);

      if (config == null)
      {
        Console.WriteLine(
          "The configuration file does not exist.");
        Console.WriteLine(
         "Use OpenExeConfiguration to create the file.");
      }

      // Create a new configuration file by saving 
      // the application configuration to a new file.
      string appName = 
        Environment.GetCommandLineArgs()[0];

      string configFile =  string.Concat(appName, 
        ".2.config");
      config.SaveAs(configFile, ConfigurationSaveMode.Full);

      // Map the new configuration file.
      ExeConfigurationFileMap configFileMap = 
          new ExeConfigurationFileMap();
      configFileMap.ExeConfigFilename = configFile;

      // Get the mapped configuration file
     config = 
        ConfigurationManager.OpenMappedExeConfiguration(
          configFileMap, ConfigurationUserLevel.None);

      // Make changes to the new configuration file. 
      // This is to show that this file is the 
      // one that is used.
      string sectionName = "consoleSection";

      ConsoleSection customSection =
        (ConsoleSection)config.GetSection(sectionName);

      if (customSection == null)
      {
          customSection = new ConsoleSection();
          config.Sections.Add(sectionName, customSection);
      }
      else
          // Change the section configuration values.
          customSection =
              (ConsoleSection)config.GetSection(sectionName);

      customSection.ConsoleElement.BackgroundColor =
          ConsoleColor.Green;
      customSection.ConsoleElement.ForegroundColor =
          ConsoleColor.Red;
 
      // Save the configuration file.
      config.Save(ConfigurationSaveMode.Modified);

      // Force a reload of the changed section. This 
      // makes the new values available for reading.
      ConfigurationManager.RefreshSection(sectionName);

      // Set console properties using the 
      // configuration values contained in the 
      // new configuration file.
      Console.BackgroundColor =
        customSection.ConsoleElement.BackgroundColor;
      Console.ForegroundColor =
        customSection.ConsoleElement.ForegroundColor;
      Console.Clear();

      Console.WriteLine();
      Console.WriteLine("Using OpenMappedExeConfiguration.");
      Console.WriteLine("Configuration file is: {0}", 
        config.FilePath);
    }
  
  // </Snippet9>

  }
  #endregion

  #region RNAME3
  //*** User Interaction Class ***//

  // Obtain user's input and provide feedback.
  // This class contains the application Main() function.
  // It calls the ConfigurationManager methods based 
  // on the user's selection.
  class ApplicationMain
  {
    // Display user's menu.
    public static void UserMenu()
    {
      string applicationName =
         Environment.GetCommandLineArgs()[0] + ".exe";
      StringBuilder buffer = new StringBuilder();

      buffer.AppendLine("Application: " + applicationName);
      buffer.AppendLine("Please, make your selection.");
      buffer.AppendLine("?    -- Display help.");
      buffer.AppendLine("Q,q  -- Exit the application.");
      buffer.Append("1    -- Use OpenExeConfiguration to get");
      buffer.AppendLine(" the roaming configuration.");
      buffer.Append("        Set console window colors");
      buffer.AppendLine(" to blue and yellow.");
      buffer.Append("2    -- Use GetSection to read or write");
      buffer.AppendLine(" the specified section.");
      buffer.Append("3    -- Use ConnectionStrings property");
      buffer.AppendLine(" to read the section.");
      buffer.Append("4    -- Use OpenExeConfiguration to get");
      buffer.AppendLine(" the application configuration.");
      buffer.Append("        Set console window colors");
      buffer.AppendLine(" to black and white.");
      buffer.Append("5    -- Use AppSettings property");
      buffer.AppendLine(" to read the section.");
      buffer.Append("6    -- Use OpenMappedExeConfiguration");
      buffer.AppendLine(" to get the specified configuration.");
      buffer.Append("        Set console window colors");
      buffer.AppendLine(" to green and red.");
      buffer.Append("7    -- Use OpenMappedMachineConfiguration");
      buffer.AppendLine(" to get the machine configuration.");

      Console.Write(buffer.ToString());
    }

    // Obtain user's input and provide
    // feedback.
    static void Main(string[] args)
    {
      // Define user selection string.
      string selection;
      
      // Get the name of the application.
      string appName = 
        Environment.GetCommandLineArgs()[0];


      // Get user selection.
      while (true)
      {
        
        UserMenu();
        Console.Write("> ");
        selection = Console.ReadLine();
        if (selection != string.Empty)
          break;
      }

      while (selection.ToLower() != "q")
      { 
        // Process user's input.
        switch (selection)
        {
          case "1":
            // Show how to use OpenExeConfiguration
            // using the configuration user level.
            UsingConfigurationManager.GetRoamingConfiguration();
            break;

          case "2":
            // Show how to use GetSection.
            UsingConfigurationManager.CreateAppSettings();
            break;

          case "3":
            // Show how to use ConnectionStrings.
            UsingConfigurationManager.ReadConnectionStrings();
            break;

          case "4":
            // Show how to use OpenExeConfiguration
            // using the configuration file path.
            UsingConfigurationManager.GetAppConfiguration();
            break;

          case "5":
            // Show how to use AppSettings.
            UsingConfigurationManager.ReadAppSettings();
            break;

          case "6":
            // Show how to use OpenMappedExeConfiguration.
            UsingConfigurationManager.MapExeConfiguration();
            break;

          case "7":
            // Show how to use OpenMappedMachineConfiguration.
            UsingConfigurationManager.MapMachineConfiguration();
            break;

          default:
            UserMenu();
            break;
        }
          Console.Write("> ");
          selection = Console.ReadLine();
      } 
    }
  }
  #endregion

// </Snippet1>