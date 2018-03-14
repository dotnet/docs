imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub DataGrid1_CurrentCellChange(ByVal sender As Object, ByVal e As EventArgs)
    Dim rect As Rectangle
    rect = DataGrid1.GetCurrentCellBounds()
    Console.WriteLine(rect.ToString)
 End Sub
 
' </Snippet1>
End Class
