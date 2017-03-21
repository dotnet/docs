    ' Add a connection string to the connection
    ' strings section and store it in the
    ' configuration file.
    Shared Sub AddConnectionStrings() 
        
        ' Get the count of the connection strings.
        Dim connStrCnt As Integer = _
        ConfigurationManager.ConnectionStrings.Count
        
        ' Define the string name.
        Dim csName As String = _
        "ConnStr" + connStrCnt.ToString()
        
        ' Get the configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)
        
        ' Add the connection string.
        Dim csSection _
        As ConnectionStringsSection = _
        config.ConnectionStrings
        csSection.ConnectionStrings.Add( _
        New ConnectionStringSettings(csName, _
        "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" _
        + "Initial Catalog=aspnetdb", "System.Data.SqlClient"))

        ' Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified)
        
        Console.WriteLine("Connection string added.")
    
    End Sub 'AddConnectionStrings
     