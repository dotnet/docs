        static void GetKeys()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionCollection sections =
                    config.Sections;


                foreach (string key in sections.Keys)
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
