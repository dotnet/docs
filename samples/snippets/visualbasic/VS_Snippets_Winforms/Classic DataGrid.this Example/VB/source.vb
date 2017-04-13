imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
Shared Sub Main()

End Sub

' <Snippet1>
Private Sub PrintCells(ByVal myGrid As DataGrid)
    Dim iRow As Integer
    Dim iCol As Integer
    Dim myTable As DataTable
    ' Assumes the DataGrid is bound to a DataTable.
    myTable = CType(DataGrid1.DataSource, DataTable)
    For iRow = 0 To myTable.Rows.Count - 1
       For iCol = 0 To myTable.Columns.Count - 1
          Console.WriteLine(myGrid(iRow, iCol))
       Next iCol
    Next iRow
 End Sub
    
' </Snippet1>
End Class
