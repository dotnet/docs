imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub RemoveRowByIndex()
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim rowCollection As DataRowCollection = table.Rows
    If rowCollection.Count = 0 Then 
        Exit Sub
    End If
    rowCollection.RemoveAt(rowCollection.Count - 1)
End Sub
' </Snippet1>

End Class
