        static void DisplayAppSettings()
        {

            try
            {

                AppSettingsReader reader = new AppSettingsReader();


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