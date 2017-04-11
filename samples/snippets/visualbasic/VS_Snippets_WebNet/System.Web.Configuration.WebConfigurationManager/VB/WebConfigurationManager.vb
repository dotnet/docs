 ' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Text



Class UsingWebConfigurationManager
   
   
   
   ' Methods to access a section at runtime. 
   
   ' <Snippet2>
   ' Show how to use the GetSection(string). 
   ' to access the connectionStrings section.
   Shared Sub GetConnectionStringsSection()
      
      ' Get the connectionStrings section.
        Dim connectionStringsSection As ConnectionStringsSection = _
        WebConfigurationManager.GetSection("connectionStrings")
      
      ' Get the connectionStrings key,value pairs collection.
        Dim connectionStrings As ConnectionStringSettingsCollection = _
        connectionStringsSection.ConnectionStrings
      
      ' Get the collection enumerator.
        Dim connectionStringsEnum As IEnumerator = _
        connectionStrings.GetEnumerator()
      
      ' Loop through the collection and 
      ' display the connectionStrings key, value pairs.
      Dim i As Integer = 0
      Console.WriteLine("[Display the connectionStrings]")
      While connectionStringsEnum.MoveNext()
         Dim name As String = connectionStrings(i).Name
            Console.WriteLine("Name: {0} Value: {1}", _
            name, connectionStrings(name))
         i += 1
      End While
      
      Console.WriteLine()
   End Sub 'GetSection1
   
   
   ' </Snippet2>
   
  
   ' <Snippet5>
   ' Show the use of GetSection(string, string). 
   ' to access the connectionStrings section.
   Shared Sub GetSection2()
      
      Try
         ' Get the connectionStrings section for the 
         ' specified Web app. This GetSection overload
         ' can olny be called from within a Web application.
            Dim connectionStringsSection As ConnectionStringsSection = _
            WebConfigurationManager.GetSection( _
            "connectionStrings", "/configTest")
         
         ' Get the connectionStrings key,value pairs collection
            Dim connectionStrings As ConnectionStringSettingsCollection = _
            connectionStringsSection.ConnectionStrings
         
         ' Get the collection enumerator.
            Dim connectionStringsEnum As IEnumerator = _
            connectionStrings.GetEnumerator()
         
         ' Loop through the collection and 
         ' display the connectionStrings key, value pairs.
         Dim i As Integer = 0
         Console.WriteLine("[Display connectionStrings]")
         While connectionStringsEnum.MoveNext()
            Dim name As String = connectionStrings(i).Name
                Console.WriteLine("Name: {0} Value: {1}", _
                name, connectionStrings(name))
            i += 1
         End While
         Console.WriteLine()
      
      Catch e As InvalidOperationException
         Dim errorMsg As String = e.ToString()
         Console.WriteLine(errorMsg)
      End Try
   End Sub 'GetSection2
   
   
   ' </Snippet5>

   ' <Snippet6>
   ' Show the use of GetWebApplicationSection(string). 
   ' to access the connectionStrings section.
   Shared Sub GetWebApplicationSection()
      
      ' Get the default connectionStrings section,
        Dim connectionStringsSection As ConnectionStringsSection = _
        WebConfigurationManager.GetWebApplicationSection( _
        "connectionStrings")
      
      ' Get the connectionStrings key,value pairs collection.
        Dim connectionStrings As ConnectionStringSettingsCollection = _
        connectionStringsSection.ConnectionStrings
      
      ' Get the collection enumerator.
        Dim connectionStringsEnum As IEnumerator = _
        connectionStrings.GetEnumerator()
      
      ' Loop through the collection and 
      ' display the connectionStrings key, value pairs.
      Dim i As Integer = 0
      Console.WriteLine("[Display connectionStrings]")
      While connectionStringsEnum.MoveNext()
         Dim name As String = connectionStrings(i).Name
            Console.WriteLine("Name: {0} Value: {1}", _
            name, connectionStrings(name))
         i += 1
      End While
      
      Console.WriteLine()
   End Sub 'GetWebApplicationSection
   
   
   ' </Snippet6>
   ' <Snippet7>
   ' Show the use of ConnectionStrings property
   ' to get the connection strings. 
   Shared Sub GetConnectionStrings()
      
      ' Get the connectionStrings key,value pairs collection.
        Dim connectionStrings As ConnectionStringSettingsCollection = _
        WebConfigurationManager.ConnectionStrings
      
      ' Get the collection enumerator.
        Dim connectionStringsEnum As IEnumerator = _
        connectionStrings.GetEnumerator()
      
      ' Loop through the collection and 
      ' display the connectionStrings key, value pairs.
      Dim i As Integer = 0
      Console.WriteLine("[Display connectionStrings]")
      While connectionStringsEnum.MoveNext()
         Dim name As String = connectionStrings(i).Name
            Console.WriteLine("Name: {0} Value: {1}", _
            name, connectionStrings(name))
         i += 1
      End While
      
      Console.WriteLine()
   End Sub 'GetConnectionStrings
   
   
   ' </Snippet7>
   
   ' <Snippet8>
   ' Show the use of AppSettings property
   ' to get the application settings.
   Shared Sub GetAppSettings()
      
      ' Get the appSettings key,value pairs collection.
        Dim appSettings As NameValueCollection = _
        WebConfigurationManager.AppSettings
      
      ' Get the collection enumerator.
        Dim appSettingsEnum As IEnumerator = _
        appSettings.GetEnumerator()
      
      ' Loop through the collection and 
      ' display the appSettings key, value pairs.
      Dim i As Integer = 0
      Console.WriteLine("[Display appSettings]")
      While appSettingsEnum.MoveNext()
         Dim key As String = appSettings.AllKeys(i)
            Console.WriteLine("Key: {0} Value: {1}", _
            key, appSettings(key))
         i += 1
      End While
      
      Console.WriteLine()
   End Sub 'GetAppSettings
   
   
   ' </Snippet8>
   
   ' Methods to access configuration files 
   ' not at runtime. These methods are
   ' used to edit configuration files.
   
   ' <Snippet9>
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


    ' </Snippet9>
    ' <Snippet10>
    ' Show how to use OpenMachineConfiguration(string).
    ' It gets the machine.config file applicabe to the
    ' specified resource and displays section 
    ' basic information. 
    Shared Sub OpenMachineConfiguration2()
        ' Get the machine.config file applicabe to the
        ' specified reosurce.
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenMachineConfiguration( _
        "configTest")

        ' Loop to get the sections. Display basic information.
        Console.WriteLine("Name, Allow Definition")
        Dim i As Integer = 0
        Dim section As ConfigurationSection
        For Each section In config.Sections
            Console.WriteLine((section.SectionInformation.Name + _
            ControlChars.Tab + _
            section.SectionInformation.AllowExeDefinition.ToString()))
            i += 1
        Next section
        Console.WriteLine("[Total number of sections: {0}]", i)

        ' Display machine.config path.
        Console.WriteLine("[File path: {0}]", config.FilePath)
    End Sub 'OpenMachineConfiguration2


    ' </Snippet10>
    ' <Snippet11>
    ' Show how to use OpenMachineConfiguration(string, string).
    ' It gets the machine.config file on the specified server and
    ' applicabe to the specified reosurce and displays section 
    ' basic information. 
    Shared Sub OpenMachineConfiguration3()
        ' Get the machine.config file applicabe to the
        ' specified reosurce and on the specified server.
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenMachineConfiguration( _
        "configTest", "myServer")

        ' Loop to get the sections. Display basic information.
        Console.WriteLine("Name, Allow Definition")
        Dim i As Integer = 0
        Dim section As ConfigurationSection
        For Each section In config.Sections
            Console.WriteLine((section.SectionInformation.Name + _
            ControlChars.Tab + _
            section.SectionInformation.AllowExeDefinition.ToString()))
            i += 1
        Next section
        Console.WriteLine("[Total number of sections: {0}]", i)

        ' Display machine.config path.
        Console.WriteLine("[File path: {0}]", config.FilePath)
    End Sub 'OpenMachineConfiguration3


    ' </Snippet11>
    ' <Snippet12>
    ' Show how to use OpenMachineConfiguration(string, string).
    ' It gets the machine.config file on the specified server,
    ' applicabe to the specified reosurce, for the specified user
    ' and displays section basic information. 
    Shared Sub OpenMachineConfiguration4()
        ' Get the current user token.
        Dim userToken As IntPtr = _
        System.Security.Principal.WindowsIdentity.GetCurrent().Token

        ' Get the machine.config file applicabe to the
        ' specified reosurce, on the specified server for the
        ' specified user.
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenMachineConfiguration( _
        "configTest", "myServer", userToken)

        ' Loop to get the sections. Display basic information.
        Console.WriteLine("Name, Allow Definition")
        Dim i As Integer = 0
        Dim section As ConfigurationSection
        For Each section In config.Sections
            Console.WriteLine((section.SectionInformation.Name + _
            ControlChars.Tab + _
            section.SectionInformation.AllowExeDefinition.ToString()))
            i += 1
        Next section
        Console.WriteLine("[Total number of sections: {0}]", i)

        ' Display machine.config path.
        Console.WriteLine("[File path: {0}]", config.FilePath)
    End Sub 'OpenMachineConfiguration4


    ' </Snippet12>
    ' <Snippet13>
    ' Show how to use OpenMachineConfiguration(string, string).
    ' It gets the machine.config file on the specified server,
    ' applicabe to the specified reosurce, for the specified user
    ' and displays section basic information. 
    Shared Sub OpenMachineConfiguration5()
        ' Set the user id and password.
        Dim user As String = _
        System.Security.Principal.WindowsIdentity.GetCurrent().Name
        ' Substitute with actual password.
        Dim password As String = "userPassword"

        ' Get the machine.config file applicabe to the
        ' specified reosurce, on the specified server for the
        ' specified user.
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenMachineConfiguration( _
        "configTest", "myServer", user, password)

        ' Loop to get the sections. Display basic information.
        Console.WriteLine("Name, Allow Definition")
        Dim i As Integer = 0
        Dim section As ConfigurationSection
        For Each section In config.Sections
            Console.WriteLine((section.SectionInformation.Name + _
            ControlChars.Tab + _
            section.SectionInformation.AllowExeDefinition.ToString()))
            i += 1
        Next section
        Console.WriteLine("[Total number of sections: {0}]", i)

        ' Display machine.config path.
        Console.WriteLine("[File path: {0}]", config.FilePath)
    End Sub 'OpenMachineConfiguration5
    
   
   ' </Snippet13>
   ' <Snippet14>
   ' Show how to use OpenWebConfiguration(string).
   ' It gets he appSettings section of a Web application 
   ' runnig on the local server. 
   Shared Sub OpenWebConfiguration1()
      ' Get the configuration object for a Web application
      ' running on the local server. 
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration("/configTest")
      
      ' Get the appSettings.
        Dim appSettings As KeyValueConfigurationCollection = _
        config.AppSettings.Settings
      
      
      ' Loop through the collection and
      ' display the appSettings key, value pairs.
      Console.WriteLine("[appSettings for app at: {0}]", "/configTest")
      Dim key As String
      For Each key In  appSettings.AllKeys
            Console.WriteLine("Name: {0} Value: {1}", _
            key, appSettings(key).Value)
      Next key
      
      Console.WriteLine()
   End Sub 'OpenWebConfiguration1
   
   
   ' </Snippet14>
   ' <Snippet15>
   ' Show how to use OpenWebConfiguration(string, string).
   ' It gets he appSettings section of a Web application 
   ' runnig on the local server. 
   Shared Sub OpenWebConfiguration2()
      ' Get the configuration object for a Web application
      ' running on the local server. 
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/configTest", "Default Web Site")
      
      ' Get the appSettings.
        Dim appSettings As KeyValueConfigurationCollection = _
        config.AppSettings.Settings
      
      
      ' Loop through the collection and
      ' display the appSettings key, value pairs.
      Console.WriteLine("[appSettings for app at: /configTest")
      Console.WriteLine(" and site: Default Web Site]")
      
      Dim key As String
      For Each key In  appSettings.AllKeys
            Console.WriteLine("Name: {0} Value: {1}", _
            key, appSettings(key).Value)
      Next key
      
      Console.WriteLine()
   End Sub 'OpenWebConfiguration2
   
   
   ' </Snippet15>
   ' <Snippet16>
   ' Show how to use OpenWebConfiguration(string, string, string).
   ' It gets he appSettings section of a Web application 
   ' runnig on the local server. 
   Shared Sub OpenWebConfiguration3()
      ' Get the configuration object for a Web application
      ' running on the local server. 
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/configTest", "Default Web Site", Nothing)
      
      ' Get the appSettings.
        Dim appSettings As KeyValueConfigurationCollection = _
        config.AppSettings.Settings
      
      ' Loop through the collection and
      ' display the appSettings key, value pairs.
      Console.WriteLine("[appSettings for app at: /configTest")
      Console.WriteLine(" site: Default Web Site")
      Console.WriteLine(" and locationSubPath: null]")
      
      Dim key As String
      For Each key In  appSettings.AllKeys
            Console.WriteLine("Name: {0} Value: {1}", _
            key, appSettings(key).Value)
      Next key
      
      Console.WriteLine()
   End Sub 'OpenWebConfiguration3
   
   
   ' </Snippet16>
   
   ' <Snippet17>
   ' Show how to use OpenWebConfiguration(string, string, 
   ' string, string).
   ' It gets he appSettings section of a Web application 
   ' running on the specified server. 
   ' If the server is remote your application must have the
   ' required access rights to the configuration file. 
   Shared Sub OpenWebConfiguration4()
      ' Get the configuration object for a Web application
      ' running on the specified server.
      ' Null for the subPath signifies no subdir. 
      Dim config As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration("/configTest", "Default Web Site", Nothing, "myServer")
      
      ' Get the appSettings.
      Dim appSettings As KeyValueConfigurationCollection = config.AppSettings.Settings
      
      
      ' Loop through the collection and
      ' display the appSettings key, value pairs.
      Console.WriteLine("[appSettings for Web app on server: myServer]")
      Dim key As String
      For Each key In  appSettings.AllKeys
         Console.WriteLine("Name: {0} Value: {1}", key, appSettings(key).Value)
      Next key
      
      Console.WriteLine()
   End Sub 'OpenWebConfiguration4
   
   
   ' </Snippet17>
   
   ' <Snippet18>
   ' Show how to use OpenWebConfiguration(string, string, 
   ' string, string, string, string).
   ' It gets he appSettings section of a Web application 
   ' running on a remote server. 
   ' If the server is remote your application must have the
   ' required access rights to the configuration file. 
   Shared Sub OpenWebConfiguration5()
      ' Get the current user.
        Dim user As String = _
        System.Security.Principal.WindowsIdentity.GetCurrent().Name
      
      ' Assign the actual password.
      Dim password As String = "userPassword"
      
      ' Get the configuration object for a Web application
      ' running on a remote server.
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/configTest", "Default Web Site", _
        Nothing, "myServer", user, password)
      
      ' Get the appSettings.
        Dim appSettings As KeyValueConfigurationCollection = _
        config.AppSettings.Settings
      
      
      ' Loop through the collection and
      ' display the appSettings key, value pairs.
        Console.WriteLine( _
        "[appSettings for Web app on server: myServer user: {0}]", user)
      Dim key As String
      For Each key In  appSettings.AllKeys
            Console.WriteLine("Name: {0} Value: {1}", _
            key, appSettings(key).Value)
      Next key
      
      Console.WriteLine()
   End Sub 'OpenWebConfiguration5
   
   ' </Snippet18>
   ' <Snippet19>
   ' Show how to use OpenWebConfiguration(string, string, 
   ' string, string, IntPtr).
   ' It gets he appSettings section of a Web application 
   ' running on a remote server. 
   ' If the serve is remote your application shall have the
   ' requires access rights to the configuration file. 
   Shared Sub OpenWebConfiguration6()
      
        Dim userToken As IntPtr = _
        System.Security.Principal.WindowsIdentity.GetCurrent().Token
      
        Dim user As String = _
        System.Security.Principal.WindowsIdentity.GetCurrent().Name
      
      ' Get the configuration object for a Web application
      ' running on a remote server.
        Dim config As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/configTest", "Default Web Site", _
        Nothing, "myServer", userToken)
      
      ' Get the appSettings.
        Dim appSettings As KeyValueConfigurationCollection = _
        config.AppSettings.Settings
      
      ' Loop through the collection and
      ' display the appSettings key, value pairs.
        Console.WriteLine( _
        "[appSettings for Web app on server: myServer user: {0}]", user)
      Dim key As String
      For Each key In  appSettings.AllKeys
            Console.WriteLine("Name: {0} Value: {1}", _
            key, appSettings(key).Value)
      Next key
      
      Console.WriteLine()
   End Sub 'OpenWebConfiguration6
   
   ' </Snippet19>
   ' <Snippet20>
   ' Utility to map virtual directories to physical ones.
   ' In the current physical directory maps 
   ' a physical sub-directory with its virtual directory.
   ' A web.config file is created for the
    ' default and the virtual directory at the appropriate level.
    'You must create a physical directory called config at the
    'level where your app is running.
   Shared Function CreateFileMap() As WebConfigurationFileMap
      
      Dim fileMap As New WebConfigurationFileMap()
      
      ' Get he physical directory where this app runs.
      ' We'll use it to map the virtual directories
      ' defined next. 
      Dim physDir As String = Environment.CurrentDirectory
      
      ' Create a VirtualDirectoryMapping object to use
      ' as the root directory for the virtual directory
      ' named config. 
      ' Note: you must assure that you have a physical subdirectory
      ' named config in the curremt physical directory where this
      ' application runs.
        Dim vDirMap As New VirtualDirectoryMapping(physDir + _
        "\config", True)
      
      ' Add vDirMap to the VirtualDirectories collection 
      ' assigning to it the virtual directory name.
      fileMap.VirtualDirectories.Add("/config", vDirMap)
      
      ' Create a VirtualDirectoryMapping object to use
      ' as the default directory for all the virtual 
      ' directories.
        Dim vDirMapBase As New VirtualDirectoryMapping(physDir, _
        True, "web.config")
      
      ' Add it to the virtual directory mapping collection.
      fileMap.VirtualDirectories.Add("/", vDirMapBase)
      
    
#If DEBUG Then
      Dim key As String
      For Each key In  fileMap.VirtualDirectories.AllKeys
            Console.WriteLine("Virtual directory: {0} Physical path: {1}", _
            fileMap.VirtualDirectories(key).VirtualDirectory, _
            fileMap.VirtualDirectories(key).PhysicalDirectory)
      Next key
#End If

      ' Return the mapping.
      Return fileMap

    End Function 'CreateFileMap
    
   
   ' </Snippet20>
   ' <Snippet21>
   ' Show how to use the OpenMappedWebConfiguration(
   ' WebConfigurationFileMap, string)
   Shared Sub OpenMappedWebConfiguration1()
      
      ' Create the configuration directories mapping.
      Dim fileMap As WebConfigurationFileMap = CreateFileMap()
      
      Try
         
         ' Get the Configuration object for the mapped
         ' virtual directory.
            Dim config As System.Configuration.Configuration = _
            WebConfigurationManager.OpenMappedWebConfiguration( _
            fileMap, "/config")
         
         ' Define a nique key for the creation of 
         ' an appSettings element entry.
         Dim appStgCnt As Integer = config.AppSettings.Settings.Count
         Dim asName As String = "AppSetting" + appStgCnt.ToString()
         
         ' Add a new element to the appSettings.
            config.AppSettings.Settings.Add(asName, _
            DateTime.Now.ToLongDateString() + " " + _
            DateTime.Now.ToLongTimeString())
         
         ' Save to the configuration file.
         config.Save(ConfigurationSaveMode.Modified)
         
         ' Display new appSettings.
            Console.WriteLine("Count:  [{0}]", _
            config.AppSettings.Settings.Count)
         Dim key As String
         For Each key In  config.AppSettings.Settings.AllKeys
                Console.WriteLine("[{0}] = [{1}]", _
                key, config.AppSettings.Settings(key).Value)
         Next key
      
      Catch err As InvalidOperationException
         Console.WriteLine(err.ToString())
      End Try
      
      Console.WriteLine()
   End Sub 'OpenMappedWebConfiguration1
   
   
    ' </Snippet21>

   ' <Snippet22>
   ' Show how to use the OpenMappedWebConfiguration(
   ' WebConfigurationFileMap, string, string).
   Shared Sub OpenMappedWebConfiguration2()
      
      ' Create the configuration directories mapping.
      Dim fileMap As WebConfigurationFileMap = CreateFileMap()
      
      Try
         
         ' Get the Configuration object for the mapped
         ' virtual directory.
            Dim config As System.Configuration.Configuration = _
            WebConfigurationManager.OpenMappedWebConfiguration( _
            fileMap, "/config", "config")
         
         ' Define a nique key for the creation of 
         ' an appSettings element entry.
         Dim appStgCnt As Integer = config.AppSettings.Settings.Count
         Dim asName As String = "AppSetting" + appStgCnt.ToString()
         
         ' Add a new element to the appSettings.
            config.AppSettings.Settings.Add(asName, _
            DateTime.Now.ToLongDateString() + " " + _
            DateTime.Now.ToLongTimeString())
         
         ' Save to the configuration file.
         config.Save(ConfigurationSaveMode.Modified)
         
         ' Display new appSettings.
            Console.WriteLine("Count:  [{0}]", _
            config.AppSettings.Settings.Count)
         Dim key As String
         For Each key In  config.AppSettings.Settings.AllKeys
                Console.WriteLine("[{0}] = [{1}]", _
                key, config.AppSettings.Settings(key).Value)
         Next key
      
      Catch err As InvalidOperationException
         Console.WriteLine(err.ToString())
      End Try
      
      Console.WriteLine()
   End Sub 'OpenMappedWebConfiguration2
   
   
    ' </Snippet22>

   ' <Snippet23>
   ' Show how to use the OpenMappedWebConfiguration(
   ' WebConfigurationFileMap, string, string, string).
   Shared Sub OpenMappedWebConfiguration3()
      
      ' Create the configuration directories mapping.
      Dim fileMap As WebConfigurationFileMap = CreateFileMap()
      
      Try
         
         ' Get the Configuration object for the mapped
         ' virtual directory.
            Dim config As System.Configuration.Configuration = _
            WebConfigurationManager.OpenMappedWebConfiguration( _
            fileMap, "/config", "config", "config")
         
         ' Define a nique key for the creation of 
         ' an appSettings element entry.
         Dim appStgCnt As Integer = config.AppSettings.Settings.Count
         Dim asName As String = "AppSetting" + appStgCnt.ToString()
         
         ' Add a new element to the appSettings.
            config.AppSettings.Settings.Add(asName, _
            DateTime.Now.ToLongDateString() + " " + _
            DateTime.Now.ToLongTimeString())
         
         ' Save to the configuration file.
         config.Save(ConfigurationSaveMode.Modified)
         
         ' Display new appSettings.
            Console.WriteLine("Count:  [{0}]", _
            config.AppSettings.Settings.Count)
         Dim key As String
         For Each key In  config.AppSettings.Settings.AllKeys
                Console.WriteLine("[{0}] = [{1}]", _
                key, config.AppSettings.Settings(key).Value)
         Next key
      
      Catch err As InvalidOperationException
         Console.WriteLine(err.ToString())
      End Try
      
      Console.WriteLine()
   End Sub 'OpenMappedWebConfiguration3
   
   
   ' </Snippet23>
    Public Overloads Shared Sub Main(ByVal args() As String)

        Dim selection As String = String.Empty

        If args.Length = 0 Then
            Console.WriteLine("Enter a selection from 0 to 18")
            Return
        End If

        selection = args(0)

        Select Case selection
            Case "0"
                GetConnectionStringsSection()

            Case "1"
                GetSection2()

            Case "2"
                GetWebApplicationSection()


            Case "3"
                OpenMachineConfiguration1()

            Case "4"
                OpenMachineConfiguration2()

            Case "5"
                OpenMachineConfiguration3()

            Case "6"
                OpenMachineConfiguration4()

            Case "7"
                OpenMachineConfiguration5()

            Case "8"
                OpenWebConfiguration1()

            Case "9"
                OpenWebConfiguration2()

            Case "10"
                OpenWebConfiguration3()

            Case "11"
                OpenWebConfiguration4()

            Case "12"
                OpenWebConfiguration5()

            Case "13"
                OpenWebConfiguration6()

            Case "14"
                OpenMappedWebConfiguration1()

            Case "15"
                OpenMappedWebConfiguration2()

            Case "16"
                OpenMappedWebConfiguration3()

            Case "17"
                GetAppSettings()

            Case "18"
                GetConnectionStrings()


            Case Else
                Console.WriteLine("Unknown selection")
        End Select

        Console.Read()
    End Sub 'Main 
End Class 'UsingWebConfigurationManager
' </Snippet1>