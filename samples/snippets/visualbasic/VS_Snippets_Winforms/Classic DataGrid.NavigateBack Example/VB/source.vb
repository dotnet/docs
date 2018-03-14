imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub GoBack(ByVal myGrid As DataGrid)
    ' Insert code to see if a Relationship exists. If not then NavigateBack.
    myGrid.NavigateBack
 End Sub
    
' </Snippet1>
End Class
