Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Protected Sub TextExpanded(myGrid As DataGrid)
        ' Get the DataTable of the grid
        Dim myTable As DataTable
        ' Assuming the grid is bound to a DataTable
        myTable = CType(myGrid.DataSource, DataTable)
        Dim i As Integer
        For i = 0 To myTable.Rows.Count - 1
            If myGrid.IsExpanded(i) Then
                Console.WriteLine(("Row " & i & " was expanded"))
            End If
        Next i
    End Sub 'TextExpanded
    ' </Snippet1>
End Class 'Form1 

