    ' Access the machine configuration file using mapping.
    ' The function uses the OpenMappedMachineConfiguration 
    ' method to access the machine configuration. 
    Public Shared Sub MapMachineConfiguration()
        ' Get the machine.config file.
        Dim machineConfig As Configuration = _
            ConfigurationManager.OpenMachineConfiguration()
        ' Get the machine.config file path.
        Dim configFile _
            As New ConfigurationFileMap( _
                machineConfig.FilePath)

        ' Map the application configuration file 
        ' to the machine configuration file.
        Dim config As Configuration = _
            ConfigurationManager. _
            OpenMappedMachineConfiguration( _
                configFile)

        ' Get the AppSettings section.
        Dim appSettingSection As AppSettingsSection = _
            DirectCast(config.GetSection("appSettings"),  _
                AppSettingsSection)
        appSettingSection.SectionInformation. _
        AllowExeDefinition = _
            ConfigurationAllowExeDefinition. _
            MachineToRoamingUser

        ' Display the configuration file sections.
        Dim sections As  _
            ConfigurationSectionCollection = _
            config.Sections

        Console.WriteLine()
        Console.WriteLine( _
            "Using OpenMappedMachineConfiguration.")
        Console.WriteLine( _
            "Sections in machine.config:")

        ' Get the sections in the machine.config.
        For Each section _
            As ConfigurationSection In sections
            Dim name As String = _
                section.SectionInformation.Name
            Console.WriteLine("Name: {0}", name)
        Next

    End Sub