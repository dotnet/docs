 Public Sub ShowTableMappings()
     ' ...
     ' create adapter
     ' ...
     adapter.TableMappings.Add("Categories", "DataCategories")
     adapter.TableMappings.Add("Orders", "DataOrders")
     adapter.TableMappings.Add("Products", "DataProducts")
     Dim message As String = "Table Mappings:" & ControlChars.Cr
     Dim i As Integer
     For i = 0 To adapter.TableMappings.Count - 1
         message &= i.ToString() & " " _
            & adapter.TableMappings(i).ToString() & ControlChars.Cr
     Next i
     Console.WriteLine(message)
 End Sub