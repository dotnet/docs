imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Function ReturnVisibleCols(ByVal myGrid As DataGrid) As Integer
    ReturnVisibleCols = myGrid.VisibleColumnCount
 End Function
    
' </Snippet1>
End Class
