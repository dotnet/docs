Private Sub PrintRows(table As DataTable)
     ' Print the first column for every row using the index.
     Dim i As Integer
     For i = 0 To table.Rows.Count - 1
         Console.WriteLine(table.Rows(i)(0))
     Next i
End Sub