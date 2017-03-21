    // Show how to use the GetSection(string) method.
    static void GetCustomSection()
    {
        try
        {

            CustomSection customSection;

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            customSection =
                config.GetSection("CustomSection") as CustomSection;

            Console.WriteLine("Section name: {0}", customSection.Name);
            Console.WriteLine("Url: {0}", customSection.Url);
            Console.WriteLine("Port: {0}", customSection.Port);

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("Using GetSection(string): {0}", err.ToString());
        }

    }