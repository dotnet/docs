imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>

 Private Sub SetParentRowBackClr(ByVal myGrid As DataGrid)
    myGrid.ParentRowsBackColor = System.Drawing.Color.Beige
 End Sub
       
' </Snippet1>
End Class
