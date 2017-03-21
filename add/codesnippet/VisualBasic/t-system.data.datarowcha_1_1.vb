 Private dataTable As DataTable    
    
 Private Sub [AddHandler]()
     dataTable = New DataTable("dataTable")
     AddHandler dataTable.RowChanged, AddressOf dataTable_Changed
 End Sub    
    
 Private Sub dataTable_Changed _
    (sender As Object, e As System.Data.DataRowChangeEventArgs)
 
     Console.WriteLine("Row Changed", e.Action, _
        e.Row(dataGrid1.CurrentCell.ColumnNumber))
 End Sub