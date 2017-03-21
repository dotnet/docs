
    ' Access a configuration file using mapping.
    ' This function uses the OpenMappedExeConfiguration 
    ' method to access a new configuration file.   
    ' It also gets the custom ConsoleSection and 
    ' sets its ConsoleEment BackgroundColor and
    ' ForegroundColor properties to green and red
    ' respectively. Then it uses these properties to
    ' set the console colors.  
    Public Shared Sub MapExeConfiguration()

        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

        Console.WriteLine(config.FilePath)

        If config Is Nothing Then
            Console.WriteLine( _
            "The configuration file does not exist.")
            Console.WriteLine( _
            "Use OpenExeConfiguration to create file.")
        End If

        ' Create a new configuration file by saving 
        ' the application configuration to a new file.
        Dim appName As String = _
            Environment.GetCommandLineArgs()(0)

        Dim configFile As String = _
            String.Concat(appName, "2.config")
        config.SaveAs(configFile, _
                      ConfigurationSaveMode.Full)

        ' Map the new configuration file.
        Dim configFileMap As New ExeConfigurationFileMap()
        configFileMap.ExeConfigFilename = configFile

        ' Get the mapped configuration file
        config = _
        ConfigurationManager.OpenMappedExeConfiguration( _
            configFileMap, ConfigurationUserLevel.None)

        ' Make changes to the new configuration file. 
        ' This is to show that this file is the 
        ' one that is used.
        Dim sectionName As String = "consoleSection"

        Dim customSection As ConsoleSection = _
            DirectCast(config.GetSection(sectionName),  _
                ConsoleSection)

        If customSection Is Nothing Then
            customSection = New ConsoleSection()
            config.Sections.Add(sectionName, customSection)
        End If

        ' Change the section configuration values.
        customSection = _
            DirectCast(config.GetSection(sectionName),  _
                ConsoleSection)
        customSection.ConsoleElement.BackgroundColor = _
            ConsoleColor.Green
        customSection.ConsoleElement.ForegroundColor = _
            ConsoleColor.Red
        ' Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified)

        ' Force a reload of the changed section. This 
        ' makes the new values available for reading.
        ConfigurationManager.RefreshSection(sectionName)

        ' Set console properties using the 
        ' configuration values contained in the 
        ' new configuration file.
        Console.BackgroundColor = _
            customSection.ConsoleElement.BackgroundColor
        Console.ForegroundColor = _
            customSection.ConsoleElement.ForegroundColor
        Console.Clear()

        Console.WriteLine()
        Console.WriteLine( _
            "Using OpenMappedExeConfiguration.")
        Console.WriteLine( _
            "Configuration file is: {0}", config.FilePath)
    End Sub
