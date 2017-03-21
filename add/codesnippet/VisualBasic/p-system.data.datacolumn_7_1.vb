Private Sub AddAutoIncrementColumn()
    Dim column As DataColumn = New DataColumn
    column.DataType = System.Type.GetType("System.Int32")
    With column
        .AutoIncrement = True
        .AutoIncrementSeed = 1000
        .AutoIncrementStep = 10
    End With

    ' Add the column to a new DataTable.
    Dim table As DataTable
    table = New DataTable
    table.Columns.Add(column)
End Sub