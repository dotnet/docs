imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub ScrollGrid(ByVal myGrid As DataGrid)
    If myGrid.FirstVisibleColumn > 5 Then
       myGrid.CurrentCell = New DataGridCell( 1,1 )
    End If
 End Sub
    
' </Snippet1>
End Class
