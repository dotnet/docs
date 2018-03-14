
Imports System
Imports System.Configuration
Imports System.Text



Class ConnectionStrings
    
    
    ' <Snippet1>
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
     
    ' </Snippet1>
    ' <Snippet2>
    Shared Sub ShowConnectionStrings() 

        ' Get the application configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' <Snippet3>
        ' Get the conectionStrings section.
        Dim csSection _
        As ConnectionStringsSection = _
        config.ConnectionStrings
        
        Dim i As Integer
        For i = 0 To ConfigurationManager.ConnectionStrings.Count
            Dim cs As ConnectionStringSettings = _
            csSection.ConnectionStrings(i)
            
            ' <Snippet4>
            Console.WriteLine( _
            "  Connection String: ""{0}""", cs.ConnectionString)
            ' </Snippet4>
            Console.WriteLine("#{0}", i)
            ' <Snippet5>
            Console.WriteLine("  Name: {0}", cs.Name)
            ' </Snippet5>
            
            ' <Snippet6>
            Console.WriteLine( _
            "  Provider Name: {0}", cs.ProviderName)
            ' </Snippet6>

        Next i
        ' </Snippet3>

    End Sub 'ShowConnectionStrings

    ' </Snippet2>
    
    ' <Snippet7>
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
        
        ' <Snippet8>
        ' Add the connection string.
        Dim csSection _
        As ConnectionStringsSection = _
        config.ConnectionStrings
        csSection.ConnectionStrings.Add( _
        New ConnectionStringSettings(csName, _
        "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" _
        + "Initial Catalog=aspnetdb", "System.Data.SqlClient"))
        ' </Snippet8>

        ' Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified)
        
        Console.WriteLine("Connection string added.")
    
    End Sub 'AddConnectionStrings
     
    ' </Snippet7>
    
    ' <Snippet9>
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
     
    
    ' </Snippet9>

    '<Snippet10>
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
    
    '</Snippet10>
    
    '<Snippet11>
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
    
    '</Snippet11>

    '<Snippet12>
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
    
    '</Snippet12>

    '<Snippet13>
    Shared Sub RemoveConnectionStrings3() 
        
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
            csCollection.RemoveAt(0)
            
            ' Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified)
            
            Console.WriteLine( _
            "Connection string settings removed.")

        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'RemoveConnectionStrings3
    
    '</Snippet13>

    '<Snippet14>
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
    
    '</Snippet14>

    '<Snippet15>
    Shared Sub GetItems2() 
        
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
            Dim cs _
            As ConnectionStringSettings = _
            csCollection("ConnStr0")
            
            Console.WriteLine("cs: {0}", cs.Name)
        
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'GetItems2
    
    '</Snippet15>
    Shared Sub Main(ByVal args() As String) 
        
        ' Display current connection strings.
        ' ShowConnectionStrings();
        ' ClearConnectionStrings();
        ' AddConnectionStrings();
        ' GetItems();
        ' GetIndex();
        RemoveConnectionStrings2()
    
    End Sub 'Main 
End Class 'ConnectionStrings