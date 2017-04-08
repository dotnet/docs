Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub DeleteRow()
     Dim row As DataRowView
     Dim view As DataView = CType(dataGrid1.DataSource, DataView)
     row = view(dataGrid1.CurrentCell.RowNumber)
     row.Delete()
End Sub
' </Snippet1>
End Class
