Private Sub AddRelation()
    Dim table As New DataTable()
    Dim column1 As DataColumn = table.Columns.Add("Column1")
    Dim column2 As DataColumn = table.Columns.Add("Column2")
    table.ChildRelations.Add("New Relation", column1, column2)
End Sub