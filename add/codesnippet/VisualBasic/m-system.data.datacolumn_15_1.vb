
 Private Sub AddDataColumn(ByVal table As DataTable)
     
    Dim typeInt32 As System.Type = _
       System.Type.GetType("System.Int32")
    Dim column As DataColumn = _
        New DataColumn("id", typeInt32)

    ' Set various properties.
    With column
       .AutoIncrement = True
       .AutoIncrementSeed = 1
       .AutoIncrementStep = 1
       .ReadOnly = True
     End With

    ' Add to Columns collection.
    table.Columns.Add(column)
 End Sub