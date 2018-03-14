imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub GetRect()
    Dim rect As Rectangle
    Dim dgc As DataGridCell
    dgc.ColumnNumber = 0
    dgc.RowNumber = 0
    rect = DataGrid1.GetCellBounds(dgc)
    Console.WriteLine(rect.ToString())
 End Sub
 
' </Snippet1>
End Class
