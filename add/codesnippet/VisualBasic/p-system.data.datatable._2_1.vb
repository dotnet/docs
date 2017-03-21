Private Sub GetTableNames(dataSet As DataSet)
     ' Print each table's TableName.
     Dim table As DataTable
     For Each table In dataSet.Tables
         Console.WriteLine(table.TableName)
     Next table
End Sub