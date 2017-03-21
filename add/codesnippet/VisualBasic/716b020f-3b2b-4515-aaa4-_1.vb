 Private Sub AddUniqueConstraint(table As DataTable)
     Dim columns(1) As DataColumn
     columns(0) = table.Columns("ID")
     columns(1) = table.Columns("Name")
     table.Constraints.Add("idNameConstraint", columns, True)
 End Sub