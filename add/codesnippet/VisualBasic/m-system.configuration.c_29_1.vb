    Shared Sub Remove()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim customSection As CustomSection = _
            config.GetSection("CustomSection")


            If Not (customSection Is Nothing) Then
                config.Sections.Remove("CustomSection")
                customSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            Else
                Console.WriteLine( _
                "CustomSection does not exists.")
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'Remove
