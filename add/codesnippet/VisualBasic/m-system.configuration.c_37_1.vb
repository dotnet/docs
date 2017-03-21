   Shared Sub GetEnumerator()
      
      Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim groups _
            As ConfigurationSectionGroupCollection = _
            config.SectionGroups

            Dim groupEnum As IEnumerator = _
            groups.GetEnumerator()
         
         Dim i As Integer = 0
         While groupEnum.MoveNext()
            Dim groupName As String = groups.GetKey(i)
            Console.WriteLine("Group name: {0}", groupName)
            i += 1
         End While

      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'GetEnumerator
   