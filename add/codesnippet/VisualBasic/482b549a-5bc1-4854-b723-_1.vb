
    ' Show how to use different modalities to save 
    ' a configuration file.
    Public Shared Sub SaveConfigurationFile()
        Try

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            ' Save the full configuration file and force save even if the file was not modified.
            config.SaveAs("MyConfigFull.config", ConfigurationSaveMode.Full, True)
            Console.WriteLine("Saved config file as MyConfigFull.config using the mode: {0}", ConfigurationSaveMode.Full.ToString())

            config = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            ' Save only the part of the configuration file that was modified. 
            config.SaveAs("MyConfigModified.config", ConfigurationSaveMode.Modified, True)
            Console.WriteLine("Saved config file as MyConfigModified.config using the mode: {0}", ConfigurationSaveMode.Modified.ToString())

            config = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            ' Save the full configuration file.
            config.SaveAs("MyConfigMinimal.config")
            Console.WriteLine("Saved config file as MyConfigMinimal.config using the mode: {0}", ConfigurationSaveMode.Minimal.ToString())

        Catch err As ConfigurationErrorsException
            Console.WriteLine("SaveConfigurationFile: {0}", err.ToString())
        End Try

    End Sub