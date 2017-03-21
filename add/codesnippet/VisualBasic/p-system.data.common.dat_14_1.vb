 Public Sub ShowTableMappings()
     ' ...
     ' create myDataAdapter
     ' ...
     myDataAdapter.TableMappings.Add("Categories", "DataCategories")
     myDataAdapter.TableMappings.Add("Orders", "DataOrders")
     myDataAdapter.TableMappings.Add("Products", "DataProducts")
     Dim myMessage As String = "Table Mappings:" + ControlChars.Cr
     Dim i As Integer
     For i = 0 To myDataAdapter.TableMappings.Count - 1
         myMessage += i.ToString() + " " _
            + myDataAdapter.TableMappings(i).ToString() + ControlChars.Cr
     Next i
     MessageBox.Show(myMessage)
 End Sub