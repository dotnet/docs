    Private Shared Sub DisplayAppSettings()

        Try

            Dim reader As New System.Configuration.AppSettingsReader()


            Dim appSettings As NameValueCollection = ConfigurationManager.AppSettings

            For i As Integer = 0 To appSettings.Count - 1
                Console.WriteLine("Key : {0} Value: {1}", appSettings.GetKey(i), appSettings(i))
            Next i

        Catch e As ConfigurationErrorsException
            Console.WriteLine("[DisplayAppSettings: {0}]", e.ToString())
        End Try

    End Sub