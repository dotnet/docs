
    // Show how to use different modalities to save 
    // a configuration file.
    static void SaveConfigurationFile()
    {
        try
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Save the full configuration file and force save even if the file was not modified.
            config.SaveAs("MyConfigFull.config", ConfigurationSaveMode.Full, true);
            Console.WriteLine("Saved config file as MyConfigFull.config using the mode: {0}",
                ConfigurationSaveMode.Full.ToString());

            config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Save only the part of the configuration file that was modified. 
            config.SaveAs("MyConfigModified.config", ConfigurationSaveMode.Modified, true);
            Console.WriteLine("Saved config file as MyConfigModified.config using the mode: {0}",
                ConfigurationSaveMode.Modified.ToString());

            config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Save the full configuration file.
            config.SaveAs("MyConfigMinimal.config");
            Console.WriteLine("Saved config file as MyConfigMinimal.config using the mode: {0}",
                ConfigurationSaveMode.Minimal.ToString());

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("SaveConfigurationFile: {0}", err.ToString());
        }

    }