imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
Shared Sub Main()

End Sub
' <Snippet1>
Private Sub SetCellValue(ByVal myGrid As DataGrid)
   Dim myCell As New DataGridCell()
   ' Use an arbitrary cell.
   myCell.RowNumber = 1
   myCell.ColumnNumber = 1
   ' Change the cell's value using the CurrentCell.
   myGrid(myCell)= "New Value"
End Sub
 
Private Sub GetCellValue(ByVal myGrid As DataGrid)
   Dim myCell As New DataGridCell()
   ' Use an arbitrary cell.
   myCell.RowNumber = 1
   myCell.ColumnNumber = 1
   Console.WriteLine(myGrid(myCell))
End Sub
    
' </Snippet1>
End Class
