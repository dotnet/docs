   ' Show the use of GetSection(string, string). 
   ' to access the connectionStrings section.
   Shared Sub GetSection2()
      
      Try
         ' Get the connectionStrings section for the 
         ' specified Web app. This GetSection overload
         ' can olny be called from within a Web application.
            Dim connectionStringsSection As ConnectionStringsSection = _
            WebConfigurationManager.GetSection( _
            "connectionStrings", "/configTest")
         
         ' Get the connectionStrings key,value pairs collection
            Dim connectionStrings As ConnectionStringSettingsCollection = _
            connectionStringsSection.ConnectionStrings
         
         ' Get the collection enumerator.
            Dim connectionStringsEnum As IEnumerator = _
            connectionStrings.GetEnumerator()
         
         ' Loop through the collection and 
         ' display the connectionStrings key, value pairs.
         Dim i As Integer = 0
         Console.WriteLine("[Display connectionStrings]")
         While connectionStringsEnum.MoveNext()
            Dim name As String = connectionStrings(i).Name
                Console.WriteLine("Name: {0} Value: {1}", _
                name, connectionStrings(name))
            i += 1
         End While
         Console.WriteLine()
      
      Catch e As InvalidOperationException
         Dim errorMsg As String = e.ToString()
         Console.WriteLine(errorMsg)
      End Try
   End Sub 'GetSection2
   
   