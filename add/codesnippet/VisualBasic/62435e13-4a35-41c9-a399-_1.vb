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
   
   