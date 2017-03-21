
        // Show how to use OpenMachineConfiguration(string, string).
        // It gets the machine.config file on the specified server,
        // applicabe to the specified reosurce, for the specified user
        // and displays section basic information. 
        static void OpenMachineConfiguration4()
        {
            // Get the current user token.
            IntPtr userToken =
                  System.Security.Principal.WindowsIdentity.GetCurrent().Token;

            // Get the machine.config file applicabe to the
            // specified reosurce, on the specified server for the
            // specified user.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenMachineConfiguration("configTest",
                "myServer", userToken);

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
