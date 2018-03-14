imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid

Shared Sub Main

End Sub
' <Snippet1>
Private Sub CompareCells()
    Dim currCell As DataGridCell
    Dim cell2 As DataGridCell
 
    currCell = DataGrid1.CurrentCell
    cell2.ColumnNumber = 0
    cell2.ColumnNumber = 0
    ' This won't return true until you select row 0, column 0.
    Console.WriteLine(currCell.Equals(cell2))
 End Sub
 
' </Snippet1>
End Class
