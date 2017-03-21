    Shared Sub ShowConnectionStrings() 

        ' Get the application configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the conectionStrings section.
        Dim csSection _
        As ConnectionStringsSection = _
        config.ConnectionStrings
        
        Dim i As Integer
        For i = 0 To ConfigurationManager.ConnectionStrings.Count
            Dim cs As ConnectionStringSettings = _
            csSection.ConnectionStrings(i)
            
            Console.WriteLine( _
            "  Connection String: ""{0}""", cs.ConnectionString)
            Console.WriteLine("#{0}", i)
            Console.WriteLine("  Name: {0}", cs.Name)
            
            Console.WriteLine( _
            "  Provider Name: {0}", cs.ProviderName)

        Next i

    End Sub 'ShowConnectionStrings
