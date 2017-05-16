imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>

 Private Sub SetWidth()
    Dim dgc As DataGridColumnStyle
    dgc = DataGrid1.TableStyles(0).GridColumnStyles("id")
    dgc.Width = 500
 End Sub
       
' </Snippet1>
End Class
