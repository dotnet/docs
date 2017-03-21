 Private Sub AddConstraint(table As DataTable)
     Dim uniqueConstraint As UniqueConstraint
     ' Assuming a column named "UniqueColumn" exists, and 
     ' its Unique property is true.
     uniqueConstraint = _
        New UniqueConstraint(table.Columns("UniqueColumn"))
     table.Constraints.Add(uniqueConstraint)
 End Sub