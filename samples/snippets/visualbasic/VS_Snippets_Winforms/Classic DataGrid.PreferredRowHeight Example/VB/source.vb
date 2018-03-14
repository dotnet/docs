imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub ChangeFontHeight(ByVal myGrid As DataGrid)
   ' Change the font first.
   myGrid.Font = New System.Drawing.Font _
   ("Microsoft Sans Serif", 15, _
   System.Drawing.FontStyle.Regular)

   myGrid.PreferredRowHeight = myGrid.Font.Height
End Sub

' </Snippet1>
End Class
