// <Snippet21>
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.IO;

// IMPORTANT: To compile this example, you must add to the project 
// a reference to the System.Configuration assembly.
//

class UsingAppSettingsSection
{
    #region UsingAppSettingsSection

    // <Snippet22>
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
    // </Snippet22>

    // <Snippet23>
    // This function shows how to write a key/value
    // pair to the appSettings section.
    static void WriteAppSettings()
    {
        try
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
               ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Create a unique key/value pair to add to 
            // the appSettings section.
            string keyName = "AppStg" + config.AppSettings.Settings.Count;
            string value = string.Concat(DateTime.Now.ToLongDateString(),
                           " ", DateTime.Now.ToLongTimeString());

            // Add the key/value pair to the appSettings 
            // section.
            // config.AppSettings.Settings.Add(keyName, value);
            System.Configuration.AppSettingsSection appSettings = config.AppSettings;
            appSettings.Settings.Add(keyName, value);

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload in memory of the changed section.
            // This to to read the section with the
            // updated values.
            ConfigurationManager.RefreshSection("appSettings");

            Console.WriteLine(
                "Added the following Key: {0} Value: {1} .", keyName, value);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception raised: {0}",
                e.Message);
        }
    }
    // </Snippet23>

    // <Snippet24>
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
    // </Snippet24>

    #endregion UsingAppSettingsSection


    #region ApplicationMain

    // This class obtains user's input and provide feedback.
    // It contains the application Main.
    class ApplicationMain
    {
        // Display user's menu.
        public static void UserMenu()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine("Please, make your selection.");
            buffer.AppendLine("1    -- Write appSettings section.");
            buffer.AppendLine("2    -- Read  appSettings section.");
            buffer.AppendLine("?    -- Display help.");
            buffer.AppendLine("Q,q  -- Exit the application.");

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

            IntializeConfigurationFile();

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
                        WriteAppSettings();
                        break;

                    case "2":
                        ReadAppSettings();
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
    #endregion ApplicationMain
}

// </Snippet21>
