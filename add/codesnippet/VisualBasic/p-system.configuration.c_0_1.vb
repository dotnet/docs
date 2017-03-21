   Shared Sub GetItems()
      
      Try
            Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

            Dim group1 As ConfigurationSectionGroup = _
            groups.Get("system.net")
         
            Dim group2 As ConfigurationSectionGroup = _
            groups.Get("system.web")
         
         
         Console.WriteLine("Group1: {0}", group1.Name)
         
         Console.WriteLine("Group2: {0}", group2.Name)
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'GetItems
