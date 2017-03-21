    Shared Sub GetIndex() 
        
        Try
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
            Dim cs _
            As ConnectionStringSettings = _
            csCollection("ConnStr0")
            
            ' Get its index;
            Dim index As Integer = _
            csCollection.IndexOf(cs)
            
            Console.WriteLine( _
            "Connection string settings index: {0}", _
            index.ToString())
        
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'GetIndex
    