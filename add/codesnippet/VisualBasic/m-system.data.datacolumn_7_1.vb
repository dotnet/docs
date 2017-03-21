Private Sub AddColumn()
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Orders").Columns
 
    ' Add a new column and return it.
    Dim column As DataColumn = columns.Add( _
        "Total", System.Type.GetType("System.Decimal"))
    column.ReadOnly = True
    column.Unique = False
End Sub