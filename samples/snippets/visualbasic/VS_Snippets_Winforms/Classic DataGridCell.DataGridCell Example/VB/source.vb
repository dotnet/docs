imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
Shared Sub Main()

End Sub

' <Snippet1>
Private Sub SetCell()
   ' Set the focus to the cell specified by the DataGridCell.
   Dim dc As DataGridCell
   dc.RowNumber = 1
   dc.ColumnNumber = 1
   DataGrid1.CurrentCell = dc
End Sub

' </Snippet1>
End Class
