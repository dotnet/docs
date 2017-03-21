        static void ForceDeclaration(
            ConfigurationSectionGroup sectionGroup)
        {

            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            sectionGroup.ForceDeclaration();

            config.Save(ConfigurationSaveMode.Full);

            Console.WriteLine(
                "Forced declaration for the group: {0}",
                sectionGroup.Name);
        }