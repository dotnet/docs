    ' Get the roaming configuration file associated 
    ' with the application.
    ' This function uses the OpenExeConfiguration(
    ' ConfigurationUserLevel userLevel) method to 
    ' get the configuration file.
    ' It also creates a custom ConsoleSection and 
    ' sets its ConsoleEment BackgroundColor and
    ' ForegroundColor properties to blue and yellow
    ' respectively. Then it uses these properties to
    ' set the console colors.  
    Public Shared Sub GetRoamingConfiguration()
        ' Define the custom section to add to the
        ' configuration file.
        Dim sectionName As String = "consoleSection"
        Dim currentSection As ConsoleSection = Nothing

        ' Get the roaming configuration 
        ' that applies to the current user.
        Dim roamingConfig As Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.PerUserRoaming)

        ' Map the roaming configuration file. This
        ' enables the application to access 
        ' the configuration file using the
        ' System.Configuration.Configuration class
        Dim configFileMap As New ExeConfigurationFileMap()
        configFileMap.ExeConfigFilename = _
            roamingConfig.FilePath

        ' Get the mapped configuration file.
        Dim config As Configuration = _
            ConfigurationManager.OpenMappedExeConfiguration( _
                configFileMap, ConfigurationUserLevel.None)

        Try
            currentSection = DirectCast( _
                config.GetSection(sectionName),  _
                ConsoleSection)

            ' Synchronize the application configuration
            ' if needed. The following two steps seem
            ' to solve some out of synch issues 
            ' between roaming and default
            ' configuration.
            config.Save(ConfigurationSaveMode.Modified)

            ' Force a reload of the changed section, 
            ' if needed. This makes the new values available 
            ' for reading.
            ConfigurationManager.RefreshSection(sectionName)

            If currentSection Is Nothing Then
                ' Create a custom configuration section.
                currentSection = New ConsoleSection()

                ' Define where in the configuration file 
                ' hierarchy the associated 
                ' configuration section can be declared.
                ' The following assignment assures that 
                ' the configuration information can be 
                ' defined in the user.config file in the 
                ' roaming user directory. 
                currentSection.SectionInformation. _
                AllowExeDefinition = _
                    ConfigurationAllowExeDefinition. _
                    MachineToLocalUser

                ' Allow the configuration section to be 
                ' overridden by lower-level configuration 
                ' files.
                ' This means that lower-level files can 
                ' contain()the section (use the same name) 
                ' and assign different values to it as 
                ' done by the function 
                ' GetApplicationConfiguration() in this
                ' example.
                currentSection.SectionInformation. _
                    AllowOverride = True

                ' Store console settings for roaming users.
                currentSection.ConsoleElement. _
                BackgroundColor = ConsoleColor.Blue
                currentSection.ConsoleElement. _
                ForegroundColor = ConsoleColor.Yellow

                ' Add configuration information to 
                ' the configuration file.
                config.Sections.Add(sectionName, _
                    currentSection)
                config.Save(ConfigurationSaveMode.Modified)
                ' Force a reload of the changed section. This 
                ' makes the new values available for reading.
                ConfigurationManager.RefreshSection( _
                    sectionName)
            End If
        Catch e As ConfigurationErrorsException
            Console.WriteLine("[Exception error: {0}]", _
                              e.ToString())
        End Try

        ' Set console properties using values
        ' stored in the configuration file.
        Console.BackgroundColor = _
            currentSection.ConsoleElement.BackgroundColor
        Console.ForegroundColor = _
            currentSection.ConsoleElement.ForegroundColor
        ' Apply the changes.
        Console.Clear()

        ' Display feedback.
        Console.WriteLine()
        Console.WriteLine( _
            "Using OpenExeConfiguration(userLevel).")
        Console.WriteLine( _
            "Configuration file is: {0}", config.FilePath)
    End Sub