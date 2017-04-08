'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics

' The following example shows how to use the ConfigurationManager 
' class in a console application.
'
' IMPORTANT: To compile this example, you must add to the project 
' a reference to the System.Configuration assembly.
'

#Region "AuxliaryClasses"

'*** Auxiliary Classes ***//

' Define a custom configuration element to be 
' contained by the ConsoleSection. This element 
' stores background and foreground colors that
' the application applies to the console window.
Public Class ConsoleConfigElement
    Inherits ConfigurationElement
    ' Create the element.
    Public Sub New()
    End Sub

    ' Create the element.
    Public Sub New(ByVal fColor As ConsoleColor, _
                   ByVal bColor As ConsoleColor)
        ForegroundColor = fColor
        BackgroundColor = bColor
    End Sub

    ' Get or set the console background color.
    <ConfigurationProperty("background", _
                           DefaultValue:=ConsoleColor.Black, _
                           IsRequired:=False)> _
    Public Property BackgroundColor() As ConsoleColor
        Get
            Return DirectCast(Me("background"), ConsoleColor)
        End Get
        Set(ByVal value As ConsoleColor)
            Me("background") = value
        End Set
    End Property

    ' Get or set the console foreground color.
    <ConfigurationProperty("foreground", _
                           DefaultValue:=ConsoleColor.White, _
                           IsRequired:=False)> _
    Public Property ForegroundColor() As ConsoleColor
        Get
            Return DirectCast(Me("foreground"), ConsoleColor)
        End Get
        Set(ByVal value As ConsoleColor)
            Me("foreground") = value
        End Set
    End Property
End Class

' Define a custom section that is used by the application
' to create custom configuration sections at the specified 
' level in the configuration hierarchy that is in the 
' proper configuration file.
' This enables the the user that has the proper access 
' rights, to make changes to the configuration files.
Public Class ConsoleSection
    Inherits ConfigurationSection
    ' Create a configuration section.
    Public Sub New()
    End Sub

    ' Set or get the ConsoleElement. 
    <ConfigurationProperty("consoleElement")> _
    Public Property ConsoleElement() As  _
        ConsoleConfigElement
        Get
            Return (DirectCast(Me("consoleElement"),  _
                    ConsoleConfigElement))
        End Get
        Set(ByVal value As ConsoleConfigElement)
            Me("consoleElement") = value
        End Set
    End Property
End Class
#End Region

#Region "ManagerInteractionClass"

'*** ConfigurationManager Interaction Class ***//

' The following code uses the ConfigurationManager class to 
' perform the following tasks:
' 1) Get the application roaming configuration file.
' 2) Get the application configuration file.
' 3) Access a specified configuration file through mapping.
' 4) Access the machine configuration file through mapping. 
' 5) Read a specified configuration section.
' 6) Read the connectionStrings section.
' 7) Read or write the appSettings section.
Public Class UsingConfigurationManager

    '<Snippet5>
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
    '</Snippet5>

    '<Snippet6>
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
    '</Snippet6>

    '<Snippet2>
    ' Get the AppSettings section.        
    ' This function uses the AppSettings property
    ' to read the appSettings configuration 
    ' section.
    Public Shared Sub ReadAppSettings()
        Try
            ' Get the AppSettings section.
            Dim appSettings As NameValueCollection = _
                ConfigurationManager.AppSettings

            ' Get the AppSettings section elements.
            Console.WriteLine()
            Console.WriteLine("Using AppSettings property.")
            Console.WriteLine("Application settings:")

            If appSettings.Count = 0 Then
                Console.WriteLine( _
                "[ReadAppSettings: {0}]", _
                "AppSettings is empty Use GetSection first.")
            End If
            Dim i As Integer = 0
            While i < appSettings.Count
                Console.WriteLine( _
                    "#{0} Key: {1} Value: {2}", _
                    i, appSettings.GetKey(i), appSettings(i))
                System.Math.Max( _
                    System.Threading.Interlocked. _
                    Increment(i), i - 1)
            End While
        Catch e As ConfigurationErrorsException
            Console.WriteLine("[ReadAppSettings: {0}]", _
                              e.ToString())
        End Try
    End Sub
    '</Snippet2>

    '<Snippet3>
    ' Get the ConnectionStrings section.        
    ' This function uses the ConnectionStrings 
    ' property to read the connectionStrings
    ' configuration section.
    Public Shared Sub ReadConnectionStrings()

        ' Get the ConnectionStrings collection.
        Dim connections _
            As ConnectionStringSettingsCollection = _
                ConfigurationManager.ConnectionStrings

        If connections.Count <> 0 Then
            Console.WriteLine()
            Console.WriteLine( _
                "Using ConnectionStrings property.")
            Console.WriteLine( _
                "Connection strings:")

            ' Get the collection elements.
            For Each connection _
                As ConnectionStringSettings In connections
                Dim name As String = connection.Name
                Dim provider As String = _
                    connection.ProviderName
                Dim connectionString As String = _
                    connection.ConnectionString

                Console.WriteLine( _
                    "Name:               {0}", name)
                Console.WriteLine( _
                    "Connection string:  {0}", _
                        connectionString)
                Console.WriteLine( _
                    "Provider:            {0}", provider)
            Next
        Else
            Console.WriteLine()
            Console.WriteLine( _
                "No connection string is defined.")
            Console.WriteLine()
        End If
    End Sub
    '</Snippet3>

    '<Snippet7>
    ' Create the AppSettings section.
    ' The function uses the GetSection(string)method 
    ' to access the configuration section. 
    ' It also adds a new element to the section collection.
    Public Shared Sub CreateAppSettings()
        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

        Dim sectionName As String = "appSettings"

        ' Add an entry to appSettings.
        Dim appStgCnt As Integer = _
            ConfigurationManager.AppSettings.Count
        Dim newKey As String = _
            "NewKey" + appStgCnt.ToString()

        Dim newValue As String = _
            DateTime.Now.ToLongDateString() + " " + _
            DateTime.Now.ToLongTimeString()

        config.AppSettings.Settings.Add(newKey, _
                                        newValue)

        ' Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified)

        ' Force a reload of the changed section. This 
        ' makes the new values available for reading.
        ConfigurationManager.RefreshSection(sectionName)

        ' Get the AppSettings section.
        Dim appSettingSection As AppSettingsSection = _
            DirectCast(config.GetSection(sectionName),  _
            AppSettingsSection)

        Console.WriteLine()
        Console.WriteLine( _
            "Using GetSection(string).")
        Console.WriteLine( _
            "AppSettings section:")
        Console.WriteLine( _
            appSettingSection.SectionInformation.GetRawXml())
    End Sub
    '</Snippet7>

    '<Snippet4>
    ' Access the machine configuration file using mapping.
    ' The function uses the OpenMappedMachineConfiguration 
    ' method to access the machine configuration. 
    Public Shared Sub MapMachineConfiguration()
        ' Get the machine.config file.
        Dim machineConfig As Configuration = _
            ConfigurationManager.OpenMachineConfiguration()
        ' Get the machine.config file path.
        Dim configFile _
            As New ConfigurationFileMap( _
                machineConfig.FilePath)

        ' Map the application configuration file 
        ' to the machine configuration file.
        Dim config As Configuration = _
            ConfigurationManager. _
            OpenMappedMachineConfiguration( _
                configFile)

        ' Get the AppSettings section.
        Dim appSettingSection As AppSettingsSection = _
            DirectCast(config.GetSection("appSettings"),  _
                AppSettingsSection)
        appSettingSection.SectionInformation. _
        AllowExeDefinition = _
            ConfigurationAllowExeDefinition. _
            MachineToRoamingUser

        ' Display the configuration file sections.
        Dim sections As  _
            ConfigurationSectionCollection = _
            config.Sections

        Console.WriteLine()
        Console.WriteLine( _
            "Using OpenMappedMachineConfiguration.")
        Console.WriteLine( _
            "Sections in machine.config:")

        ' Get the sections in the machine.config.
        For Each section _
            As ConfigurationSection In sections
            Dim name As String = _
                section.SectionInformation.Name
            Console.WriteLine("Name: {0}", name)
        Next

    End Sub
    '</Snippet4>

    '<Snippet9>

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

    '</Snippet9>



End Class
#End Region

#Region "UserInteractionClass"

'*** User Interaction Class ***//

' Obtain user's input and provide feedback.
' This class contains the application Main() function.
' It calls the ConfigurationManager methods based 
' on the user's selection.
Class ApplicationMain
    ' Display user's menu.
    Public Shared Sub UserMenu()
        Dim applicationName As String = _
            Environment.GetCommandLineArgs()(0) + ".exe"
        Dim buffer As New StringBuilder()

        buffer.AppendLine("Application: " + applicationName)
        buffer.AppendLine("Please, make your selection.")
        buffer.AppendLine("?    -- Display help.")
        buffer.AppendLine("Q,q  -- Exit the application.")
        buffer.Append( _
        "1    -- Use OpenExeConfiguration to get")
        buffer.AppendLine(" the roaming configuration.")
        buffer.Append("        Set console window colors")
        buffer.AppendLine(" to blue and yellow.")
        buffer.Append( _
        "2    -- Use GetSection to read or write")
        buffer.AppendLine(" the specified section.")
        buffer.Append( _
        "3    -- Use ConnectionStrings property")
        buffer.AppendLine(" to read the section.")
        buffer.Append( _
        "4    -- Use OpenExeConfiguration to get")
        buffer.AppendLine(" the application configuration.")
        buffer.Append("        Set console window colors")
        buffer.AppendLine(" to black and white.")
        buffer.Append("5    -- Use AppSettings property")
        buffer.AppendLine(" to read the section.")
        buffer.Append( _
        "6    -- Use OpenMappedExeConfiguration")
        buffer.AppendLine( _
        " to get the specified configuration.")
        buffer.Append("        Set console window colors")
        buffer.AppendLine(" to green and red.")
        buffer.Append( _
        "7    -- Use OpenMappedMachineConfiguration")
        buffer.AppendLine( _
        " to get the machine configuration.")

        Console.Write(buffer.ToString())
    End Sub

    ' Obtain user's input and provide
    ' feedback.
    Shared Sub Main(ByVal args As String())
        ' Define user selection string.
        Dim selection As String = Nothing

        ' Get the name of the application.
        Dim appName As String = _
            Environment.GetCommandLineArgs()(0)


        ' Get user selection.
        While True

            UserMenu()
            Console.Write("> ")
            selection = Console.ReadLine()
            If selection <> String.Empty Then
                Exit While
            End If
        End While

        While selection.ToLower() <> "q"
            ' Process user's input.
            Select Case selection
                Case "1"
                    ' Show how to use OpenExeConfiguration
                    ' using the configuration user level.
                    UsingConfigurationManager. _
                        GetRoamingConfiguration()
                    Exit Select
                Case "2"

                    ' Show how to use GetSection.
                    UsingConfigurationManager. _
                        CreateAppSettings()
                    Exit Select
                Case "3"

                    ' Show how to use ConnectionStrings.
                    UsingConfigurationManager. _
                        ReadConnectionStrings()
                    Exit Select
                Case "4"

                    ' Show how to use OpenExeConfiguration
                    ' using the configuration file path.
                    UsingConfigurationManager. _
                        GetAppConfiguration()
                    Exit Select
                Case "5"

                    ' Show how to use AppSettings.
                    UsingConfigurationManager. _
                        ReadAppSettings()
                    Exit Select
                Case "6"

                    ' Show how to use 
                    ' OpenMappedExeConfiguration.
                    UsingConfigurationManager. _
                        MapExeConfiguration()
                    Exit Select
                Case "7"

                    ' Show how to use 
                    ' OpenMappedMachineConfiguration.
                    UsingConfigurationManager. _
                        MapMachineConfiguration()
                    Exit Select
                Case Else

                    UserMenu()
                    Exit Select
            End Select
            Console.Write("> ")
            selection = Console.ReadLine()
        End While
    End Sub
End Class
#End Region

'</Snippet1>