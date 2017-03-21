
        // Show how to use OpenMachineConfiguration(string).
        // It gets the machine.config file applicabe to the
        // specified resource and displays section 
        // basic information. 
        static void OpenMachineConfiguration2()
        {
            // Get the machine.config file applicabe to the
            // specified reosurce.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenMachineConfiguration("configTest");

            // Loop to get the sections. Display basic information.
            Console.WriteLine("Name, Allow Definition");
            int i = 0;
            foreach (ConfigurationSection section in config.Sections)
            {
                Console.WriteLine(
                    section.SectionInformation.Name + "\t" +
                section.SectionInformation.AllowExeDefinition);
                i += 1;

            }
            Console.WriteLine("[Total number of sections: {0}]", i);

            // Display machine.config path.
            Console.WriteLine("[File path: {0}]", config.FilePath);

        }
