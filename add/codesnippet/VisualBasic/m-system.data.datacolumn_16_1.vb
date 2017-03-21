Private Sub RemoveColumn( _
    columnName As String, table As DataTable)

    Dim columns As DataColumnCollection = table.Columns
    If columns.Contains(columnName) Then 
        If columns.CanRemove(columns(columnName)) Then 
           columns.Remove(columnName)
        End If
    End If
End Sub