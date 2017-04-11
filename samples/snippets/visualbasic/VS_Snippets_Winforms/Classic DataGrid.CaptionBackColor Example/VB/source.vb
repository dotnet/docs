imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>

 Private Sub SetCaptionBackClr(ByVal myGrid As DataGrid)
    myGrid.CaptionBackColor = System.Drawing.Color.Blue
 End Sub
    
' </Snippet1>
End Class
