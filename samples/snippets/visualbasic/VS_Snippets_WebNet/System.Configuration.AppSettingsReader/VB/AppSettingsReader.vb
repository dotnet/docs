' <Snippet1>
Imports System
Imports System.Collections.Specialized
Imports System.Configuration


Class UsingAppSettingsReader
    ' <Snippet2>
    Private Shared Sub DisplayAppSettings()

        Try
            ' <Snippet3>

            Dim reader As New System.Configuration.AppSettingsReader()

            ' </Snippet3>

            Dim appSettings As NameValueCollection = ConfigurationManager.AppSettings

            For i As Integer = 0 To appSettings.Count - 1
                Console.WriteLine("Key : {0} Value: {1}", appSettings.GetKey(i), appSettings(i))
            Next i

        Catch e As ConfigurationErrorsException
            Console.WriteLine("[DisplayAppSettings: {0}]", e.ToString())
        End Try

    End Sub
    ' </Snippet2>

    Private Shared Sub CreateAppSettings()
        Try
            ' Get the count of the Application Settings.
            Dim appSettingsCount As Integer = ConfigurationManager.AppSettings.Count

            Dim asName As String = "Key" & appSettingsCount.ToString()

            ' Get the configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Add an Application setting.
            config.AppSettings.Settings.Add(asName, Date.Now.ToLongDateString() & " " & Date.Now.ToLongTimeString())

            ' Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified)

            ' Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings")
        Catch e As ConfigurationErrorsException
            Console.WriteLine("[CreateAppSettings: {0}]", e.ToString())
        End Try
    End Sub

    Shared Sub Main(ByVal args() As String)

        Dim selection As String = ""

        Do While selection.ToLower() <> "q"
            ' Create appSettings section.
            CreateAppSettings()

            ' Display appSettings section.
            DisplayAppSettings()

            Console.WriteLine()
            Console.WriteLine("Enter 'Q' to exit or press enter to continue.")
            Console.Write("> ")

            selection = Console.ReadLine()
        Loop
    End Sub
End Class
' </Snippet1>