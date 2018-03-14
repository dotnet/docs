imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected grid As DataGrid
' <Snippet1>
Private Sub DataGrid1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
    Dim hti As DataGrid.HitTestInfo
    hti = grid.HitTest(New Point(e.X, e.Y))
    Select Case hti.Type
    Case System.Windows.Forms.DataGrid.HitTestType.None 
       Console.WriteLine("You clicked the background.")
    Case System.Windows.Forms.DataGrid.HitTestType.Cell 
       Console.WriteLine("You clicked cell at row " & hti.Row & ", col " & hti.Column)
    Case System.Windows.Forms.DataGrid.HitTestType.ColumnHeader
       Console.WriteLine("You clicked the column header for column " & hti.Column)
    Case System.Windows.Forms.DataGrid.HitTestType.RowHeader 
       Console.WriteLine("You clicked the row header for row " & hti.Row)
    Case System.Windows.Forms.DataGrid.HitTestType.ColumnResize
       Console.WriteLine("You clicked the column resizer for column " & hti.Column)
    Case System.Windows.Forms.DataGrid.HitTestType.RowResize 
       Console.WriteLine("You clicked the row resizer for row " & hti.Row)
    Case System.Windows.Forms.DataGrid.HitTestType.Caption
       Console.WriteLine("You clicked the caption")
    Case System.Windows.Forms.DataGrid.HitTestType.ParentRows 
       Console.WriteLine("You clicked the parent row")
    End Select
 End Sub
 
' </Snippet1>
End Class
