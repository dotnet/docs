imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Function ReturnVisibleRows(ByVal myGrid As DataGrid)As Integer
    ReturnVisibleRows = myGrid.VisibleRowCount
 End Function
 
' </Snippet1>
End Class
