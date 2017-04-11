imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>

 Private Sub NavToGrid(ByVal myGrid As DataGrid)
    ' Presumes a relationship named OrderDetails exists.
    myGrid.NavigateTo( 2, "OrderDetails" )
 End Sub
       
' </Snippet1>
End Class
