imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms

Public Class Form1: Inherits Form
Shared Sub Main()

End Sub
 Protected dataGrid1 As DataGrid
' <Snippet1>
Private Sub PrintTableMappingName _
(ByVal myColumnStyle As DataGridColumnStyle)
    Console.WriteLine _
    (myColumnStyle.DataGridTableStyle.MappingName)
End Sub
' </Snippet1>
End Class
