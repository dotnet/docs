    ' Get the application configuration file.
    ' This function uses the 
    ' OpenExeConfiguration(string)method 
    ' to get the application configuration file. 
    ' It also creates a custom ConsoleSection and 
    ' sets its ConsoleEment BackgroundColor and
    ' ForegroundColor properties to black and white
    ' respectively. Then it uses these properties to
    ' set the console colors.  
    Public Shared Sub GetAppConfiguration()
        ' Get the application path needed to obtain
        ' the application configuration file.
#If DEBUG Then
        Dim applicationName As String = _
            Environment.GetCommandLineArgs()(0)
#Else
            Dim applicationName As String = _
                Environment.GetCommandLineArgs()(0) + ".exe"
#End If

        Dim exePath As String = _
        System.IO.Path.Combine( _
            Environment.CurrentDirectory, applicationName)

        ' Get the configuration file. The file name has
        ' this format appname.exe.config.
        Dim config As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration(exePath)

        Try

            ' Create a custom configuration section
            ' having the same name that is used in the 
            ' roaming configuration file.
            ' This is because the configuration section 
            ' can be overridden by lower-level 
            ' configuration files. 
            ' See the GetRoamingConfiguration() function in 
            ' this example.
            Dim sectionName As String = "consoleSection"
            Dim customSection As New ConsoleSection()

            If config.Sections(sectionName) Is Nothing Then
                ' Create a custom section if it does 
                ' not exist yet.

                ' Store console settings.
                customSection.ConsoleElement. _
                    BackgroundColor = ConsoleColor.Black
                customSection.ConsoleElement. _
                    ForegroundColor = ConsoleColor.White

                ' Add configuration information to the
                ' configuration file.
                config.Sections.Add(sectionName, _
                                    customSection)
                config.Save(ConfigurationSaveMode.Modified)
                ' Force a reload of the changed section.
                ' This makes the new values available 
                ' for reading.
                ConfigurationManager.RefreshSection( _
                    sectionName)
            End If
            ' Set console properties using values
            ' stored in the configuration file.
            customSection = DirectCast( _
                config.GetSection(sectionName),  _
                    ConsoleSection)
            Console.BackgroundColor = _
                customSection.ConsoleElement.BackgroundColor
            Console.ForegroundColor = _
                customSection.ConsoleElement.ForegroundColor
            ' Apply the changes.
            Console.Clear()
        Catch e As ConfigurationErrorsException
            Console.WriteLine("[Error exception: {0}]", _
                              e.ToString())
        End Try

        ' Display feedback.
        Console.WriteLine()
        Console.WriteLine( _
            "Using OpenExeConfiguration(string).")
        ' Display the current configuration file path.
        Console.WriteLine( _
            "Configuration file is: {0}", config.FilePath)
    End Sub