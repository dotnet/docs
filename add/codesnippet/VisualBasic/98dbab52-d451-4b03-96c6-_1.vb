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
   
   