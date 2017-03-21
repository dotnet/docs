   ' Get the collection keys i.e., the
   ' group names.
   Shared Sub GetKeys()
      
      Try
            Dim config _
          As System.Configuration.Configuration = _
          ConfigurationManager.OpenExeConfiguration( _
          ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

         Dim key As String
         For Each key In  groups.Keys
            
            Console.WriteLine("Key value: {0}", key)
         Next key
      
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'GetKeys
      