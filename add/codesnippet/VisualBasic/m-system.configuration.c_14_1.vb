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