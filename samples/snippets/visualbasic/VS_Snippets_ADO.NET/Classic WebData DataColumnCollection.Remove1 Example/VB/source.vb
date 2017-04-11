imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub RemoveColumnByName(columnName As String)

    ' Get the DataColumnCollection from a DataTable in a DataSet.
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Orders").Columns

    If columns.Contains(columnName) Then 
        If columns.CanRemove(columns(columnName)) Then 
            columns.Remove(columnName)
        End If
    End If
 End Sub
 ' </Snippet1>

End Class
