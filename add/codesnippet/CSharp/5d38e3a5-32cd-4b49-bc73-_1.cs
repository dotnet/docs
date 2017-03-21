
        // Show how to use OpenMachineConfiguration(string, string).
        // It gets the machine.config file on the specified server,
        // applicabe to the specified reosurce, for the specified user
        // and displays section basic information. 
        static void OpenMachineConfiguration5()
        {
            // Set the user id and password.
            string user =
                  System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // Substitute with actual password.
            string password = "userPassword";

            // Get the machine.config file applicabe to the
            // specified reosurce, on the specified server for the
            // specified user.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenMachineConfiguration("configTest",
                "myServer", user, password);

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
