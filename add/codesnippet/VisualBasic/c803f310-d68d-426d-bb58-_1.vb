    Shared Sub RemoveConnectionStrings() 
        
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
            ' with the specified name.
            Dim cs As ConnectionStringSettings = _
            csCollection("ConnStr0")
            
            ' Remove it.
            If Not (cs Is Nothing) Then
                ' Remove the element.
                csCollection.Remove(cs)
                
                ' Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified)
                
                Console.WriteLine( _
                "Connection string settings removed.")
            Else
                Console.WriteLine( _
                "Connection string settings does not exist.")
            End If
        
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'RemoveConnectionStrings
    