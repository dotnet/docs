
        // Show how to use OpenMachineConfiguration().
        // It gets the machine.config file on the current 
        // machine and displays section information. 
        static void OpenMachineConfiguration1()
        {
            // Get the machine.config file on the current machine.
            System.Configuration.Configuration config =
                    WebConfigurationManager.OpenMachineConfiguration();

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
