Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub SetGridLineColor(myGrid As DataGrid, newcolor As System.Drawing.Color)
        myGrid.GridLineColor = newcolor
    End Sub
    ' </Snippet1>
End Class

