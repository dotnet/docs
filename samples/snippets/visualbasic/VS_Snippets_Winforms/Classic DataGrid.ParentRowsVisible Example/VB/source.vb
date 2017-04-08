imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub ToggleParentRowsVisible(ByRef myGrid As DataGrid)
    myGrid.ParentRowsVisible = myGrid.ParentRowsVisible Xor True
 End Sub
 
' </Snippet1>
End Class
