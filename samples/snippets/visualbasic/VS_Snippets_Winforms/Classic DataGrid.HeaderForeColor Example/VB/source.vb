imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub SetHeaderForeClr(ByVal myGrid As DataGrid, ByVal newColor As System.Drawing.Color)
    myGrid.HeaderForeColor = newColor
 End Sub
   
' </Snippet1>
End Class
