        static void Remove()
        {

            try
            {
 
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                   ConfigurationUserLevel.None);

                ConfigurationSectionGroup customGroup =
                    config.SectionGroups.Get("CustomGroup");

                if (customGroup != null)
                {
                    config.SectionGroups.Remove("CustomGroup");
                    config.Save(ConfigurationSaveMode.Full);
                }
                else
                    Console.WriteLine(
                        "CustomGroup does not exists.");

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }