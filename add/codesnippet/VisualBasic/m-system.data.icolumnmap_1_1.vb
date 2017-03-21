 Public Sub FindDataColumnMapping()
     ' ...
     ' create columnMappings
     ' ...
     If Not columnMappings.Contains("Description") Then
         Console.WriteLine("Error: no such table in collection.")
     Else
        Console.WriteLine("Name: {0}", _
            columnMappings("Description").ToString())
        Console.WriteLine("Index: {0}", _
            columnMappings.IndexOf("Description").ToString())
     End If
 End Sub