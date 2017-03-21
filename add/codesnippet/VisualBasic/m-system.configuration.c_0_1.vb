   Shared Sub Clear()
      
      Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)


         config.SectionGroups.Clear()
         
         config.Save(ConfigurationSaveMode.Full)
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'Clear
   