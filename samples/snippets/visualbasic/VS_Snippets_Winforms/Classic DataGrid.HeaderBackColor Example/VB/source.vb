imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>

 Private Sub SetHeaderBackClr(Byval myGrid As DataGrid)
    myGrid.HeaderBackColor = System.Drawing.Color.CadetBlue
 End Sub
    
' </Snippet1>
End Class
