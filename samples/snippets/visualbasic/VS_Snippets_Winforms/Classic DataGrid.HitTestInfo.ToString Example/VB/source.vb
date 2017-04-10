Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub dataGrid1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim myHitTest As System.Windows.Forms.DataGrid.HitTestInfo
        ' Use the DataGrid control's HitTest method with the x and y properties.
        myHitTest = dataGrid1.HitTest(e.X, e.Y)
        Console.WriteLine(("ToString " & myHitTest.ToString()))
    End Sub 'dataGrid1_MouseDown
    ' </Snippet1>
End Class 'Form1 

