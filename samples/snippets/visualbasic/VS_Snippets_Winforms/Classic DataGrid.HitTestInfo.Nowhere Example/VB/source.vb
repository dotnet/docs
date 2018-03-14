Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub dataGrid1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If dataGrid1.HitTest(e.X, e.Y).Equals(DataGrid.HitTestInfo.Nowhere) Then
            Console.WriteLine("Nowhere")
        End If
    End Sub 'dataGrid1_MouseDown
    ' </Snippet1>
End Class 'Form1 

