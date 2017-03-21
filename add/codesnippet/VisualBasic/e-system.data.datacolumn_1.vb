 Private Sub AddEventHandler(table As DataTable)
     Dim columns As DataColumnCollection = table.Columns
     AddHandler columns.CollectionChanged, _
        AddressOf ColumnsCollection_Changed
 End Sub    
    
 Private Sub ColumnsCollection_Changed _
    (sender As Object, e As System.ComponentModel. _
    CollectionChangeEventArgs)

     Dim columns As DataColumnCollection = _
        CType(sender, DataColumnCollection)
     Console.WriteLine("ColumnsCollectionChanged: " _
        & columns.Count.ToString())
End Sub