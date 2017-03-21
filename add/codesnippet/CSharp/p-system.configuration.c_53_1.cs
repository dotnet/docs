        // Get the collection keys i.e., the
        // group names.
        static void GetKeys()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionGroupCollection groups =
                    config.SectionGroups;

                foreach (string key in groups.Keys)
                {

                    Console.WriteLine(
                     "Key value: {0}", key);
                }


            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
