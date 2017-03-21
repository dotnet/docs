 Private Sub GetDataTable(constraint As UniqueConstraint)
     Dim table As DataTable = constraint.Table
     Console.WriteLine(table.TableName)
 End Sub