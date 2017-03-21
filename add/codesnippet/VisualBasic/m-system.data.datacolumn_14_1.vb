Private Sub GetIndex(ByVal table As DataTable)
    Dim iCol As Integer
    Dim columns As DataColumnCollection = table.Columns
    If columns.Contains("City") Then
       Console.WriteLine(columns.IndexOf("City"))
    End If
End Sub