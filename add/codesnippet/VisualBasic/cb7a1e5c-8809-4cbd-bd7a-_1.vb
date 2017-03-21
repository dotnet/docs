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
   
   