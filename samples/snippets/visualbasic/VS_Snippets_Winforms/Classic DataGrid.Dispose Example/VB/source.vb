imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>

 Private Sub DisposeGridResources(ByVal myGrid As DataGrid)
    myGrid.Dispose
    myGrid = Nothing
 End Sub
       
' </Snippet1>
End Class
