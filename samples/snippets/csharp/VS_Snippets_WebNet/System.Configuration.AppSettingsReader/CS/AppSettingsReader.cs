// <Snippet1>
using System;
using System.Collections.Specialized;
using System.Configuration;


    class UsingAppSettingsReader
    {
        // <Snippet2>
        static void DisplayAppSettings()
        {

            try
            {
                // <Snippet3>

                AppSettingsReader reader = new AppSettingsReader();

                // </Snippet3>

                NameValueCollection appSettings = ConfigurationManager.AppSettings;

                for (int i = 0; i < appSettings.Count; i++)
                {
                    Console.WriteLine("Key : {0} Value: {1}",
                      appSettings.GetKey(i), appSettings[i]);
                }

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[DisplayAppSettings: {0}]", e.ToString());
            }

        }
        // </Snippet2>

        static void CreateAppSettings()
        {
            try
            {
                // Get the count of the Application Settings.
                int appSettingsCount = ConfigurationManager.AppSettings.Count;

                string asName = "Key" + appSettingsCount.ToString();

                // Get the configuration file.
                System.Configuration.Configuration config =
                  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Add an Application setting.
                config.AppSettings.Settings.Add(asName,
                  DateTime.Now.ToLongDateString() + " " +
                  DateTime.Now.ToLongTimeString());

                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified);

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[CreateAppSettings: {0}]",
                    e.ToString());
            }
        }

        static void Main(string[] args)
        {
            
            string selection = "";

            while (selection.ToLower() != "q")
            {
                // Create appSettings section.
                CreateAppSettings();

                // Display appSettings section.
                DisplayAppSettings();

                Console.WriteLine();
                Console.WriteLine("Enter 'Q' to exit or press enter to continue.");
                Console.Write("> ");

                selection = Console.ReadLine();
            }
        }
    }
// </Snippet1>
