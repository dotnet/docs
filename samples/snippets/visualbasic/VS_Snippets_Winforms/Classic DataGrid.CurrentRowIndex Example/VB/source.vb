imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub GetSelectedIndex(ByVal myGrid As DataGrid)
    Console.WriteLine(myGrid.CurrentRowIndex)
 End Sub
 
 Private Sub SetSelectedIndex(ByVal myGrid As DataGrid, ByVal selIndex As Integer)
    myGrid.CurrentRowIndex= selIndex
 End Sub
 
' </Snippet1>
End Class
