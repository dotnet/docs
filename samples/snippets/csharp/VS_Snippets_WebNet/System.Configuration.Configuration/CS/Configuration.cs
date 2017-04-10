//<Snippet31>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;

// Before compiling this application, 
// remember to reference the System.Configuration assembly in your project. 
#region CustomSection class

//<Snippet1>
// Define a custom section. This class is used to
// populate the configuration file.
// It creates the following custom section:
//  <CustomSection name="Contoso" url="http://www.contoso.com" port="8080" />.
public sealed class CustomSection : ConfigurationSection
{

    public CustomSection()
    {

    }


    [ConfigurationProperty("name",
     DefaultValue = "Contoso",
     IsRequired = true,
     IsKey = true)]
    public string Name
    {
        get
        {
            return (string)this["name"];
        }
        set
        {
            this["name"] = value;
        }
    }

    [ConfigurationProperty("url",
        DefaultValue = "http://www.contoso.com",
        IsRequired = true)]
    [RegexStringValidator(@"\w+:\/\/[\w.]+\S*")]
    public string Url
    {
        get
        {
            return (string)this["url"];
        }
        set
        {
            this["url"] = value;
        }
    }

    [ConfigurationProperty("port",
        DefaultValue = (int)8080,
        IsRequired = false)]
    [IntegerValidator(MinValue = 0,
        MaxValue = 8080, ExcludeRange = false)]
    public int Port
    {
        get
        {
            return (int)this["port"];
        }
        set
        {
            this["port"] = value;
        }
    }



}
//</Snippet1>

#endregion

#region Using Configuration Class
class UsingConfigurationClass
{

    //<Snippet2>

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
    //</Snippet2>

    //<Snippet3>
    // Show how to use the GetSection(string) method.
    static void GetCustomSection()
    {
        try
        {

            CustomSection customSection;

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            customSection =
                config.GetSection("CustomSection") as CustomSection;

            Console.WriteLine("Section name: {0}", customSection.Name);
            Console.WriteLine("Url: {0}", customSection.Url);
            Console.WriteLine("Port: {0}", customSection.Port);

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("Using GetSection(string): {0}", err.ToString());
        }

    }
    //</Snippet3>

    //<Snippet4>

    // Show how to use different modalities to save 
    // a configuration file.
    static void SaveConfigurationFile()
    {
        try
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Save the full configuration file and force save even if the file was not modified.
            config.SaveAs("MyConfigFull.config", ConfigurationSaveMode.Full, true);
            Console.WriteLine("Saved config file as MyConfigFull.config using the mode: {0}",
                ConfigurationSaveMode.Full.ToString());

            config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Save only the part of the configuration file that was modified. 
            config.SaveAs("MyConfigModified.config", ConfigurationSaveMode.Modified, true);
            Console.WriteLine("Saved config file as MyConfigModified.config using the mode: {0}",
                ConfigurationSaveMode.Modified.ToString());

            config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Save the full configuration file.
            config.SaveAs("MyConfigMinimal.config");
            Console.WriteLine("Saved config file as MyConfigMinimal.config using the mode: {0}",
                ConfigurationSaveMode.Minimal.ToString());

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("SaveConfigurationFile: {0}", err.ToString());
        }

    }
    //</Snippet4>


    // Show how use the AppSettings and ConnectionStrings 
    // properties.
    static void GetSections(string section)
    {
        try
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Get the selected section.
            switch (section)
            {
                case "appSettings":
                    //<Snippet5>
                    try
                    {
                        AppSettingsSection appSettings =
                            config.AppSettings as AppSettingsSection;
                        Console.WriteLine("Section name: {0}",
                                appSettings.SectionInformation.SectionName);

                        // Get the AppSettings section elements.
                        Console.WriteLine();
                        Console.WriteLine("Using AppSettings property.");
                        Console.WriteLine("Application settings:");
                        // Get the KeyValueConfigurationCollection 
                        // from the configuration.
                        KeyValueConfigurationCollection settings =
                          config.AppSettings.Settings;

                        // Display each KeyValueConfigurationElement.
                        foreach (KeyValueConfigurationElement keyValueElement in settings)
                        {
                            Console.WriteLine("Key: {0}", keyValueElement.Key);
                            Console.WriteLine("Value: {0}", keyValueElement.Value);
                            Console.WriteLine();
                        }
                    }
                    catch (ConfigurationErrorsException e)
                    {
                        Console.WriteLine("Using AppSettings property: {0}",
                            e.ToString());
                    }
                    //</Snippet5>
                    break;

                case "connectionStrings":
                    //<Snippet6>
                    ConnectionStringsSection
                        conStrSection =
                        config.ConnectionStrings as ConnectionStringsSection;
                    Console.WriteLine("Section name: {0}",
                        conStrSection.SectionInformation.SectionName);

                    try
                    {
                        if (conStrSection.ConnectionStrings.Count != 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Using ConnectionStrings property.");
                            Console.WriteLine("Connection strings:");

                            // Get the collection elements.
                            foreach (ConnectionStringSettings connection in
                              conStrSection.ConnectionStrings)
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
                    }
                    catch (ConfigurationErrorsException e)
                    {
                        Console.WriteLine("Using ConnectionStrings property: {0}",
                            e.ToString());
                    }
                    //</Snippet6>
                    break;

                default:
                    Console.WriteLine(
                        "GetSections: Unknown section (0)", section);
                    break;
            }

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("GetSections: (0)", err.ToString());
        }

    }

    // Show how to use the Configuration object properties 
    // to obtain configuration file information.
    static void GetConfigurationInformation()
    {
        try
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            Console.WriteLine("Reading configuration information:");

            //<Snippet7>
            ContextInformation evalContext =
                config.EvaluationContext as ContextInformation;
            Console.WriteLine("Machine level: {0}",
                evalContext.IsMachineLevel.ToString());
            //</Snippet7>
                    
            //<Snippet8>
            string filePath = config.FilePath;
            Console.WriteLine("File path: {0}", filePath);
            //</Snippet8>
             
            //<Snippet9>
            bool hasFile = config.HasFile;
            Console.WriteLine("Has file: {0}", hasFile.ToString());
            //</Snippet9>
                   
              
            //<Snippet10>
            ConfigurationSectionGroupCollection
                groups = config.SectionGroups;
            Console.WriteLine("Groups: {0}", groups.Count.ToString());
            foreach (ConfigurationSectionGroup group in groups)
            {
                Console.WriteLine("Group Name: {0}", group.Name);
               // Console.WriteLine("Group Type: {0}", group.Type);
            }
            //</Snippet10>
                  

            //<Snippet11>
            ConfigurationSectionCollection
                sections = config.Sections;
            Console.WriteLine("Sections: {0}", sections.Count.ToString());
            //</Snippet11>
            
        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("GetConfigurationInformation: {0}",err.ToString());
        }

    }

#endregion 

#region Application Main
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
            buffer.AppendLine("Make your selection.");
            buffer.AppendLine("?    -- Display help.");
            buffer.AppendLine("Q,q  -- Exit the application.");
            
            buffer.Append("1    -- Instantiate the");
            buffer.AppendLine(" Configuration class.");

            buffer.Append("2    -- Use GetSection(string) to read ");
            buffer.AppendLine(" a custom section.");
            
            buffer.Append("3    -- Use SaveAs methods");
            buffer.AppendLine(" to save the configuration file.");

            buffer.Append("4    -- Use AppSettings property to read");
            buffer.AppendLine(" the appSettings section.");
            buffer.Append("5    -- Use ConnectionStrings property to read");
            buffer.AppendLine(" the connectionStrings section.");

            buffer.Append("6    -- Use Configuration class properties");
            buffer.AppendLine(" to obtain configuration information.");

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
                        // Show how to create an instance of the Configuration class.
                        CreateConfigurationFile();
                        break;

                    case "2":
                        // Show how to use GetSection(string) method.
                        GetCustomSection();
                        break;

                    case "3":
                        // Show how to use ConnectionStrings.
                        SaveConfigurationFile();
                        break;

                    case "4":
                        // Show how to use the AppSettings property.
                        GetSections("appSettings");
                        break;

                    case "5":
                        // Show how to use the ConnectionStrings property.
                        GetSections("connectionStrings");
                        break;

                    case "6":
                        // Show how to obtain configuration file information.
                        GetConfigurationInformation();
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

}
//</Snippet31>