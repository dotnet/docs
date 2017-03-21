        ' Object to hold 2-dimensional array returned by GetAllSettings.
        ' Integer to hold counter.
        Dim MySettings(,) As String
        Dim intSettings As Integer
        ' Place some settings in the registry.
        SaveSetting("MyApp", "Startup", "Top", "75")
        SaveSetting("MyApp", "Startup", "Left", "50")
        ' Retrieve the settings.
        MySettings = GetAllSettings("MyApp", "Startup")
        For intSettings = LBound(MySettings, 1) To UBound(MySettings, 1)
            WriteLine(1, MySettings(intSettings, 0))
            WriteLine(1, MySettings(intSettings, 1))
        Next intSettings
        DeleteSetting("MyApp")