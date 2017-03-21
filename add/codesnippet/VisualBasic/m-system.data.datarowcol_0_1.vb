 Private Sub FindInPrimaryKeyColumn(ByVal table As DataTable, _
    ByVal pkValue As Long)
    ' Find the number pkValue in the primary key 
    ' column of the table.
    Dim foundRow As DataRow = table.Rows.Find(pkValue)

    ' Print the value of column 1 of the found row.
    If Not (foundRow Is Nothing) Then
        Console.WriteLine(foundRow(1).ToString())
    End If
End Sub