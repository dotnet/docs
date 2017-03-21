    Shared Sub GetItems() 
        
        Try
            ' Get the application configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Clear the connection strings collection.
            Dim csSection _
            As ConnectionStringsSection = _
            config.ConnectionStrings
            Dim csCollection _
            As ConnectionStringSettingsCollection = _
            csSection.ConnectionStrings
            
            ' Get the connection string setting element
            ' with the specified index.
            Dim cs _
            As ConnectionStringSettings = _
            csCollection(0)
            
            Console.WriteLine("cs: {0}", cs.Name)
        
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'GetItems
    