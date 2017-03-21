
   
        // Show the use of the AppSettings property
        // to get the application settings. 
        static void GetAppSettings()
        {

            // Get the appSettings key,value pairs collection.
            NameValueCollection appSettings =
                WebConfigurationManager.AppSettings
                as NameValueCollection;

            // Get the collection enumerator.
            IEnumerator appSettingsEnum =
                appSettings.GetEnumerator();

            // Loop through the collection and 
            // display the appSettings key, value pairs.
            int i = 0;
            Console.WriteLine("[Display appSettings]");
            while (appSettingsEnum.MoveNext())
            {
                string key = appSettings.AllKeys[i].ToString();
                Console.WriteLine("Key: {0} Value: {1}",
                key, appSettings[key]);
                i += 1;
            }

            Console.WriteLine();
        }
