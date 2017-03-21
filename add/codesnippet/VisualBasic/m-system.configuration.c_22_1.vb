    ' Clear connection strings collection.
    Shared Sub ClearConnectionStrings() 
        
        ' Get the application configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Clear the connection strings collection.
        Dim csSection _
        As ConnectionStringsSection = _
        config.ConnectionStrings
        csSection.ConnectionStrings.Clear()
        
        ' Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified)
        
        Console.WriteLine("Connection strings cleared.")
    
    End Sub 'ClearConnectionStrings
     
    