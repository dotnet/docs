' <Snippet21>
Imports System
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Text
Imports System.IO

' IMPORTANT: To compile this example, you must add to the project 
' a reference to the System.Configuration assembly.
'

Class UsingAppSettingsSection
#Region "UsingAppSettingsSection"

    ' <Snippet22>
    ' This function shows how to use the File property of the
    ' appSettings section.
    ' The File property is used to specify an auxiliary 
    ' configuration file.
    ' Usually you create an auxiliary file off-line to store 
    ' additional settings that you can modify as needed without
    ' causing an application restart,as in the case of a Web 
    ' application.
    ' These settings are then added to the ones defined in the
    ' application configuration file.
    Private Shared Sub IntializeConfigurationFile()
        ' Create a set of unique key/value pairs to store in
        ' the appSettings section of an auxiliary configuration
        ' file.
        Dim time1 As String = String.Concat(Date.Now.ToLongDateString(), " ", Date.Now.ToLongTimeString())

        Dim time2 As String = String.Concat(Date.Now.ToLongDateString(), " ", New Date(2009, 6, 30).ToLongTimeString())

        Dim buffer() As String = {"<appSettings>", "<add key='AuxAppStg0' value='" & time1 & "'/>", "<add key='AuxAppStg1' value='" & time2 & "'/>", "</appSettings>"}

        ' Create an auxiliary configuration file and store the
        ' appSettings defined before.
        ' Note creating a file at run-time is just for demo 
        ' purposes to run this example.
        File.WriteAllLines("auxiliaryFile.config", buffer)

        ' Get the current configuration associated
        ' with the application.
        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        ' Associate the auxiliary with the default
        ' configuration file. 
        Dim appSettings As System.Configuration.AppSettingsSection = config.AppSettings
        appSettings.File = "auxiliaryFile.config"

        ' Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified)

        ' Force a reload in memory of the 
        ' changed section.
        ConfigurationManager.RefreshSection("appSettings")

    End Sub
    ' </Snippet22>

    ' <Snippet23>
    ' This function shows how to write a key/value
    ' pair to the appSettings section.
    Private Shared Sub WriteAppSettings()
        Try
            ' Get the application configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Create a unique key/value pair to add to 
            ' the appSettings section.
            Dim keyName As String = "AppStg" & config.AppSettings.Settings.Count
            Dim value As String = String.Concat(Date.Now.ToLongDateString(), " ", Date.Now.ToLongTimeString())

            ' Add the key/value pair to the appSettings 
            ' section.
            ' config.AppSettings.Settings.Add(keyName, value);
            Dim appSettings As System.Configuration.AppSettingsSection = config.AppSettings
            appSettings.Settings.Add(keyName, value)

            ' Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified)

            ' Force a reload in memory of the changed section.
            ' This to to read the section with the
            ' updated values.
            ConfigurationManager.RefreshSection("appSettings")

            Console.WriteLine("Added the following Key: {0} Value: {1} .", keyName, value)
        Catch e As Exception
            Console.WriteLine("Exception raised: {0}", e.Message)
        End Try
    End Sub
    ' </Snippet23>

    ' <Snippet24>
    ' This function shows how to read the key/value
    ' pairs (settings collection)contained in the 
    ' appSettings section.
    Private Shared Sub ReadAppSettings()
        Try

            ' Get the configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Get the appSettings section.
            Dim appSettings As System.Configuration.AppSettingsSection = CType(config.GetSection("appSettings"), System.Configuration.AppSettingsSection)

            ' Get the auxiliary file name.
            Console.WriteLine("Auxiliary file: {0}", config.AppSettings.File)


            ' Get the settings collection (key/value pairs).
            If appSettings.Settings.Count <> 0 Then
                For Each key As String In appSettings.Settings.AllKeys
                    Dim value As String = appSettings.Settings(key).Value
                    Console.WriteLine("Key: {0} Value: {1}", key, value)
                Next key
            Else
                Console.WriteLine("The appSettings section is empty. Write first.")
            End If
        Catch e As Exception
            Console.WriteLine("Exception raised: {0}", e.Message)
        End Try
    End Sub
    ' </Snippet24>

#End Region ' UsingAppSettingsSection


#Region "ApplicationMain"

    Shared Sub UserMenu()
        Dim buffer As New StringBuilder()

        buffer.AppendLine("Please, make your selection.")
        buffer.AppendLine("1    -- Write appSettings section.")
        buffer.AppendLine("2    -- Read  appSettings section.")
        buffer.AppendLine("?    -- Display help.")
        buffer.AppendLine("Q,q  -- Exit the application.")

        Console.Write(buffer.ToString())
    End Sub

    ' Obtain user's input and provide
    ' feedback.
    Shared Sub Main(ByVal args() As String)
        ' Define user selection string.
        Dim selection As String

        ' Get the name of the application.
        Dim appName As String = Environment.GetCommandLineArgs()(0)

        IntializeConfigurationFile()

        ' Get user selection.
        Do

            UserMenu()
            Console.Write("> ")
            selection = Console.ReadLine()
            If selection <> String.Empty Then
                Exit Do
            End If
        Loop

        Do While selection.ToLower() <> "q"
            ' Process user's input.
            Select Case selection
                Case "1"
                    WriteAppSettings()

                Case "2"
                    ReadAppSettings()

                Case Else
                    UserMenu()
            End Select
            Console.Write("> ")
            selection = Console.ReadLine()
        Loop
    End Sub
    ' End Class
#End Region ' ApplicationMain
End Class
' </Snippet21>