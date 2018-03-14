imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected DataGrid1 As DataGrid
' <Snippet1>
    Private Sub DataGrid1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Console.WriteLine()
        Dim myHitTest As DataGrid.HitTestInfo
        ' Use the DataGrid control's HitTest method with the x and y properties.
        myHitTest = DataGrid1.HitTest(e.X, e.Y)
        Console.WriteLine("Column " & myHitTest.Column)
        Console.WriteLine("Row " & myHitTest.Row)
        Console.WriteLine("Type " & myHitTest.Type)
        Console.WriteLine("ToString " & myHitTest.ToString)
        Console.WriteLine("Format " & myHitTest.Type.ToString)
    End Sub

' </Snippet1>
End Class
