imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>

 Private Sub SetParentRowsForeClr(ByVal myGrid As DataGrid)
    myGrid.ParentRowsForeColor = System.Drawing.Color.Tomato
 End Sub
       
' </Snippet1>
End Class
