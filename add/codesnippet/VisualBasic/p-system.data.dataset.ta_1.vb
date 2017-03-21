 Private Sub PrintRows(ByVal dataSet As DataSet)
    Dim table As DataTable
    Dim row As DataRow
    Dim column As DataColumn
    ' For each table in the DataSet, print the row values.
    For Each table in dataSet.Tables
       For Each row In table.Rows
          For Each column in table.Columns
             Console.WriteLine(row(column))
          Next column
       Next row
    Next table
 End Sub