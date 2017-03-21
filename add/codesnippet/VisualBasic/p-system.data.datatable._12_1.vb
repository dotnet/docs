Private Sub PrintValues(ByVal table As DataTable)
    Dim row As DataRow
    Dim column As DataColumn
    For Each row in table.Rows
       For Each column In table.Columns
          Console.WriteLine(row(column))
       Next
    Next
End Sub