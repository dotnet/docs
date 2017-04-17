imports System
imports System.Data


Public Class Sample

' <Snippet1>
Private Sub RemoveColumn(columnName As String, table As DataTable)
    Dim columns As DataColumnCollection = table.Columns

    If columns.Contains(columnName) Then 
        If columns.CanRemove(columns(columnName)) Then 
            columns.Remove(columnName)
        End If
    End If
End Sub
' </Snippet1>

End Class
