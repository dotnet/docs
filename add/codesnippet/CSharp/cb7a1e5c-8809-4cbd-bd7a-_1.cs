
        // Show how to use OpenWebConfiguration(string, string, string).
        // It gets he appSettings section of a Web application 
        // runnig on the local server. 
        static void OpenWebConfiguration3()
        {
            // Get the configuration object for a Web application
            // running on the local server. 
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenWebConfiguration(
                "/configTest", "Default Web Site", null)
                as System.Configuration.Configuration;

            // Get the appSettings.
            KeyValueConfigurationCollection appSettings =
                 config.AppSettings.Settings;

            // Loop through the collection and
            // display the appSettings key, value pairs.
            Console.WriteLine(
                "[appSettings for app at: /configTest");
            Console.WriteLine(" site: Default Web Site");
            Console.WriteLine(" and locationSubPath: null]");
            
            foreach (string key in appSettings.AllKeys)
            {
                Console.WriteLine("Name: {0} Value: {1}",
                key, appSettings[key].Value);
            }

            Console.WriteLine();
        }
