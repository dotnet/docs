imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
Shared Sub Main
End Sub
' <Snippet1>
Private Sub PrintCellRowAndCol()
    Dim myCell As DataGridCell
    myCell = DataGrid1.CurrentCell
    Console.WriteLine(myCell.RowNumber)
    Console.WriteLine(myCell.ColumnNumber)
    ' Prints the value of the cell through the DataTable.
    Dim myTable As DataTable
    ' Assumes the DataGrid is bound to a DataTable.
    myTable = CType(DataGrid1.DataSource, DataTable)
    Console.WriteLine(myTable.Rows(myCell.RowNumber)(myCell.ColumnNumber))
 End Sub

' </Snippet1>
End Class
