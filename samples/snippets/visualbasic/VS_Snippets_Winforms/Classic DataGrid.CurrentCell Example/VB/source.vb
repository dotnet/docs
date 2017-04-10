imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub SetCellWithFocus(ByVal myGrid As DataGrid)
    ' Set the current cell to cell 1, row 1.
    myGrid.CurrentCell = New DataGridCell(1,1)
 End Sub
 
 Private Sub DataGrid1_GotFocus(ByVal Sender As Object, ByVal e As EventArgs)
    Console.WriteLine(DataGrid1.CurrentCell.ColumnNumber & " " & _
       DataGrid1.CurrentCell.RowNumber)
 End Sub
    
' </Snippet1>
End Class
