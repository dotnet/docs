imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub ToggleColumnHeadersVisible(ByVal myGrid As DataGrid)
    myGrid.ColumnHeadersVisible = myGrid.ColumnHeadersVisible Xor True
 End Sub

' </Snippet1>
End Class
