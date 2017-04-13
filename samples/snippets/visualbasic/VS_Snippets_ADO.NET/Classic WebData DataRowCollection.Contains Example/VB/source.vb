imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid
Protected Label1 As Label
Protected Edit1 As TextBox

' <Snippet1>
 Private Sub ColContains()
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim rowCollection As DataRowCollection = table.Rows
    If rowCollection.Contains(Edit1.Text) Then
       Label1.Text = "At least one row contains " & Edit1.Text 
    Else
       Label1.Text = "No row contains the value in its primary key field"
    End If
End Sub
' </Snippet1>

End Class
