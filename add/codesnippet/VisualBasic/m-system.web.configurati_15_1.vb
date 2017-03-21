   ' Show how to use OpenMachineConfiguration().
   ' It gets the machine.config file on the current 
   ' machine and displays section information. 
   Shared Sub OpenMachineConfiguration1()
      ' Get the machine.config file on the current machine.
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenMachineConfiguration()
      
      ' Loop to get the sections. Display basic information.
      Console.WriteLine("Name, Allow Definition")
      Dim i As Integer = 0
      Dim section As ConfigurationSection
      For Each section In  config.Sections
            Console.WriteLine((section.SectionInformation.Name + _
            ControlChars.Tab + _
            section.SectionInformation.AllowExeDefinition.ToString()))
            i += 1
        Next section
        Console.WriteLine("[Total number of sections: {0}]", i)

        ' Display machine.config path.
        Console.WriteLine("[File path: {0}]", config.FilePath)
    End Sub 'OpenMachineConfiguration1

