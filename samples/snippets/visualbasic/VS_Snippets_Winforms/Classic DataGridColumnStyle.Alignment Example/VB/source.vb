imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
 Protected dataSet1 As DataSet
' <Snippet1>
Private Sub SetAlign()
   Dim myColumnStyle As DataGridColumnStyle 
   For each myColumnStyle In dataGrid1.TableStyles("Customers"). _
   GridColumnStyles
      myColumnStyle.Alignment = HorizontalAlignment.Center
   Next
End Sub

' </Snippet1>
End Class
