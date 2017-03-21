        ' Place some settings in the registry.
        SaveSetting("MyApp", "Startup", "Top", "75")
        SaveSetting("MyApp", "Startup", "Left", "50")
        Console.WriteLine(GetSetting("MyApp", "Startup", "Left", "25"))
        DeleteSetting("MyApp")