        static void GetItems()
        {

            try
            {
                System.Configuration.Configuration config =
                 ConfigurationManager.OpenExeConfiguration(
                 ConfigurationUserLevel.None);

                ConfigurationSectionGroupCollection groups =
                    config.SectionGroups;

                ConfigurationSectionGroup group1 =
                    groups.Get("system.net");

                ConfigurationSectionGroup group2 =
                groups.Get("system.web");


                Console.WriteLine(
                     "Group1: {0}", group1.Name);

                Console.WriteLine(
                    "Group2: {0}", group2.Name);

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
