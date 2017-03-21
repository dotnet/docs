   ' Show the use of GetWebApplicationSection(string). 
   ' to access the connectionStrings section.
   Shared Sub GetWebApplicationSection()
      
      ' Get the default connectionStrings section,
        Dim connectionStringsSection As ConnectionStringsSection = _
        WebConfigurationManager.GetWebApplicationSection( _
        "connectionStrings")
      
      ' Get the connectionStrings key,value pairs collection.
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
   End Sub 'GetWebApplicationSection
   
   