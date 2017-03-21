    ' Show how to create an instance of the Configuration class
    ' that represents this application configuration file.  
    Public Shared Sub CreateConfigurationFile()
        Try

            ' Create a custom configuration section.
            Dim customSection As New CustomSection()

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Create the section entry  
            ' in <configSections> and the 
            ' related target section in <configuration>.
            If config.Sections("CustomSection") Is Nothing Then
                config.Sections.Add("CustomSection", customSection)
            End If

            ' Create and add an entry to appSettings section.

            Dim conStringname As String = "LocalSqlServer"
            Dim conString As String = "data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true"
            Dim providerName As String = "System.Data.SqlClient"

            Dim connStrSettings As New ConnectionStringSettings()
            connStrSettings.Name = conStringname
            connStrSettings.ConnectionString = conString
            connStrSettings.ProviderName = providerName

            config.ConnectionStrings.ConnectionStrings.Add(connStrSettings)

            ' Add an entry to appSettings section.
            Dim appStgCnt As Integer = ConfigurationManager.AppSettings.Count
            Dim newKey As String = "NewKey" & appStgCnt.ToString()

            Dim newValue As String = Date.Now.ToLongDateString() & " " & Date.Now.ToLongTimeString()

            config.AppSettings.Settings.Add(newKey, newValue)

            ' Save the configuration file.
            customSection.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)

            Console.WriteLine("Created configuration file: {0}", config.FilePath)

        Catch err As ConfigurationErrorsException
            Console.WriteLine("CreateConfigurationFile: {0}", err.ToString())
        End Try

    End Sub