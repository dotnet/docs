    Shared Sub RemoveConnectionStrings2() 
        
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
            
            ' Remove the element.
            csCollection.Remove("ConnStr0")
            
            
            ' Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified)
            
            Console.WriteLine( _
            "Connection string settings removed.")

        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'RemoveConnectionStrings2
    