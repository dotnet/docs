    Shared Sub Clear()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            config.Sections.Clear()

            config.Save( _
            ConfigurationSaveMode.Full)
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'Clear

