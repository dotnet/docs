    ' Show how to use OpenMachineConfiguration(string, string).
    ' It gets the machine.config file on the specified server,
    ' applicabe to the specified reosurce, for the specified user
    ' and displays section basic information. 
    Shared Sub OpenMachineConfiguration5()
        ' Set the user id and password.
        Dim user As String = _
        System.Security.Principal.WindowsIdentity.GetCurrent().Name
        ' Substitute with actual password.
        Dim password As String = "userPassword"

        ' Get the machine.config file applicabe to the
        ' specified reosurce, on the specified server for the
        ' specified user.
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenMachineConfiguration( _
        "configTest", "myServer", user, password)

        ' Loop to get the sections. Display basic information.
        Console.WriteLine("Name, Allow Definition")
        Dim i As Integer = 0
        Dim section As ConfigurationSection
        For Each section In config.Sections
            Console.WriteLine((section.SectionInformation.Name + _
            ControlChars.Tab + _
            section.SectionInformation.AllowExeDefinition.ToString()))
            i += 1
        Next section
        Console.WriteLine("[Total number of sections: {0}]", i)

        ' Display machine.config path.
        Console.WriteLine("[File path: {0}]", config.FilePath)
    End Sub 'OpenMachineConfiguration5
    
   