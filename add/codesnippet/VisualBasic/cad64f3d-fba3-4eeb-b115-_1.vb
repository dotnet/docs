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
   
   