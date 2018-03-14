imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected DataGrid1 As DataGrid

 Protected Sub Method
' <Snippet1>
If DataGrid1.CaptionText = "" Then
    DataGrid1.CaptionText = "Microsoft DataGrid"
End If

' </Snippet1>
 End Sub
End Class
