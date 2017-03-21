   Shared Sub GetGroup()
      
      Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

            Dim customGroup _
            As ConfigurationSectionGroup = _
            groups.Get("CustomGroup")
         
         
         If customGroup Is Nothing Then
                Console.WriteLine( _
                "Failed to load CustomGroup.")
         Else
            ' Display section information
                Console.WriteLine("Name:       {0}", _
                customGroup.Name)
                Console.WriteLine("Type:   {0}", _
                customGroup.Type)
         End If
      
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'GetGroup
   