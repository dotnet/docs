 Private Sub AddUniqueConstraint(table As DataTable)
     table.Constraints.Add("idConstraint", table.Columns("id"), True)
 End Sub