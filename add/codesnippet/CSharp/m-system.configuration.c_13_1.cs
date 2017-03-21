        static void GetGroup()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionGroup customGroup =
                    config.SectionGroups.Get("CustomGroup");


                if (customGroup == null)
                    Console.WriteLine(
                        "Failed to load CustomSection.");
                else
                {
                    // Display section information
                    Console.WriteLine("Section group name:       {0}",
                        customGroup.SectionGroupName);
                    Console.WriteLine("Name:       {0}",
                        customGroup.Name);
                    Console.WriteLine("Type:   {0}",
                        customGroup.Type);

                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }