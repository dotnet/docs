   Shared Sub Remove()
      
      Try
         
            Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

            Dim customGroup _
            As ConfigurationSectionGroup = groups.Get("CustomGroup")
         
         If Not (customGroup Is Nothing) Then
            config.SectionGroups.Remove("CustomGroup")
            config.Save(ConfigurationSaveMode.Full)
         Else
                Console.WriteLine( _
                "CustomGroup does not exists.")
         End If
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'Remove
   