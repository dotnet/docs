        ' Place some settings in the registry.
        SaveSetting("MyApp", "Startup", "Top", "75")
        SaveSetting("MyApp", "Startup", "Left", "50")
        ' Remove section and all its settings from registry.
        DeleteSetting("MyApp", "Startup")
        ' Remove MyApp from the registry.
        DeleteSetting("MyApp")