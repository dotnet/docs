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
   
   