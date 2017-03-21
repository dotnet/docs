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
   