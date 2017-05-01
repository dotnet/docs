imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form
Shared Sub Main()

End Sub

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub PrintCell(sender As Object, e As MouseEventArgs)
   Dim thisGrid As DataGrid = CType(sender, DataGrid)
   Dim myDataGridCell As DataGridCell = thisGrid.CurrentCell
   Dim bm As BindingManagerBase = _
   BindingContext (thisGrid.DataSource, thisGrid.DataMember)
   Dim drv As DataRowView = CType(bm.Current, DataRowView)
   Console.WriteLine(drv(myDataGridCell.ColumnNumber))
   Console.WriteLine(myDataGridCell.RowNumber)
End Sub

' </Snippet1>
End Class
