
        // Show how to use the OpenMappedWebConfiguration(
        // WebConfigurationFileMap, string)
        static void OpenMappedWebConfiguration1()
        {

            // Create the configuration directories mapping.
            WebConfigurationFileMap fileMap = 
                CreateFileMap();

            try
            {

                // Get the Configuration object for the mapped
                // virtual directory.
                System.Configuration.Configuration config =
                    WebConfigurationManager.OpenMappedWebConfiguration(fileMap, 
                    "/config");

                // Define a nique key for the creation of 
                // an appSettings element entry.
                int appStgCnt = config.AppSettings.Settings.Count;
                string asName = "AppSetting" + appStgCnt.ToString();

                // Add a new element to the appSettings.
                config.AppSettings.Settings.Add(asName,
                    DateTime.Now.ToLongDateString() + " " +
                    DateTime.Now.ToLongTimeString());

                // Save to the configuration file.
                config.Save(ConfigurationSaveMode.Modified);
              
                // Display new appSettings.
                Console.WriteLine("Count:  [{0}]", config.AppSettings.Settings.Count);
                foreach (string key in config.AppSettings.Settings.AllKeys)
                { 
                    Console.WriteLine("[{0}] = [{1}]", key, 
                        config.AppSettings.Settings[key].Value);
                }
                
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.ToString());
            }

            Console.WriteLine();
        }
