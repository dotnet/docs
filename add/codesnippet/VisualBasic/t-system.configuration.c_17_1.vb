    ' Create a connectionn string element and add it to
    ' the connection strings section.
    Shared Sub New() 

        ' Get the application configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)
        
        ' Get the current connection strings count.
        Dim connStrCnt As Integer = _
        ConfigurationManager.ConnectionStrings.Count
        
        ' Create the connection string name. 
        Dim csName As String = "ConnStr" + connStrCnt.ToString()
        
        ' Create a connection string element and
        ' save it to the configuration file.
        ' Create a connection string element.
        Dim csSettings _
        As New ConnectionStringSettings( _
        csName, _
        "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" + _
        "Initial Catalog=aspnetdb", "System.Data.SqlClient")
        
        ' Get the connection strings section.
        Dim csSection _
        As ConnectionStringsSection = _
        config.ConnectionStrings
        
        ' Add the new element.
        csSection.ConnectionStrings.Add(csSettings)
        
        ' Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified)
    
    End Sub 'New
     