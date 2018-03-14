imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form
Shared Sub Main()

End Sub


 Protected dataGrid1 As DataGrid
' <Snippet1>
    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim myGrid As DataGrid = CType(sender, DataGrid)
        Dim myCell As DataGridCell = myGrid.CurrentCell
        Console.WriteLine(myCell.ToString)
    End Sub

' </Snippet1>
End Class
