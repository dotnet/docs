    Shared Sub AddSection()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim customSection _
            As New CustomSection()


            Dim index As String = _
            config.Sections.Count.ToString()

            customSection.FileName = _
            "newFile" + index + ".txt"

            Dim sectionName As String = _
            "CustomSection" + index

            Dim ts As New TimeSpan(0, 15, 0)
            customSection.MaxIdleTime = ts
            customSection.MaxUsers = 100

            config.Sections.Add(sectionName, customSection)
            customSection.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'AddSection

