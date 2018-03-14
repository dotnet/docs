imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub SetCaptionFont(ByRef myGrid As DataGrid, newFont As System.Drawing.Font)
    myGrid.CaptionFont = newFont
 End Sub

' </Snippet1>
End Class
