Private Sub AddColumn(table As DataTable )
    ' Create a new column and set its properties.
    Dim column As DataColumn = New DataColumn("ID", _
        Type.GetType("System.Int32"), "", MappingType.Attribute)
    column.DataType = Type.GetType("System.String")
    column.ColumnMapping = MappingType.Element

    ' Add the column the table's columns collection.
    table.Columns.Add(column)
End Sub