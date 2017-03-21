   ' Show how to use the GetSection(string). 
   ' to access the connectionStrings section.
   Shared Sub GetConnectionStringsSection()
      
      ' Get the connectionStrings section.
        Dim connectionStringsSection As ConnectionStringsSection = _
        WebConfigurationManager.GetSection("connectionStrings")
      
      ' Get the connectionStrings key,value pairs collection.
        Dim connectionStrings As ConnectionStringSettingsCollection = _
        connectionStringsSection.ConnectionStrings
      
      ' Get the collection enumerator.
        Dim connectionStringsEnum As IEnumerator = _
        connectionStrings.GetEnumerator()
      
      ' Loop through the collection and 
      ' display the connectionStrings key, value pairs.
      Dim i As Integer = 0
      Console.WriteLine("[Display the connectionStrings]")
      While connectionStringsEnum.MoveNext()
         Dim name As String = connectionStrings(i).Name
            Console.WriteLine("Name: {0} Value: {1}", _
            name, connectionStrings(name))
         i += 1
      End While
      
      Console.WriteLine()
   End Sub 'GetSection1
   
   