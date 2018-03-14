Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
    ' <Snippet1>
Public Class Form1
   Inherits Form
   Protected dataGrid1 As DataGrid
   Protected myDataSet As DataSet
    
   Private Sub PaintCell(sender As Object, e As MouseEventArgs)
      ' Use the HitTest method to get a HitTestInfo object.
      Dim hi As DataGrid.HitTestInfo
      Dim grid As DataGrid = CType(sender, DataGrid)
      hi = grid.HitTest(e.X, e.Y)
      ' Test if the clicked area was a cell.
      If hi.Type = DataGrid.HitTestType.Cell Then
         ' If it's a cell, get the GridTable and ListManager of the
         ' clicked table.         
         Dim dgt As DataGridTableStyle = dataGrid1.TableStyles(0)
         Dim cm As CurrencyManager = CType(Me.BindingContext _
         (myDataSet.Tables(dgt.MappingName)), CurrencyManager)
         ' Get the Rectangle of the clicked cell.
         Dim cellRect As Rectangle
         cellRect = grid.GetCellBounds(hi.Row, hi.Column)
         ' Get the clicked DataGridTextBoxColumn.
         Dim gridCol As MyGridColumn = CType _
         (dgt.GridColumnStyles(hi.Column), MyGridColumn)
         ' Get the Graphics object for the form.
         Dim g As Graphics = dataGrid1.CreateGraphics()
         ' Create two new Brush objects: a fore brush and back brush.
         Dim fBrush As New SolidBrush(Color.Blue)
         Dim bBrush As New SolidBrush(Color.Yellow)
         ' Invoke the Paint method to paint the cell with the brushes.
         gridCol.PaintCol(g, cellRect, cm, hi.Row, bBrush, fBrush, False)
      End If
   End Sub 'PaintCell
End Class 'Form1 

Public Class MyGridColumn
Inherits DataGridTextBoxColumn
   Public Sub PaintCol(g As Graphics , cellRect As Rectangle , _
      cm As CurrencyManager , rowNum As integer , bBrush as Brush , _
      fBrush As Brush , isVisible As Boolean )
      me.Paint(g, cellRect, cm, rowNum, bBrush, fBrush, isVisible)
   End Sub
End Class
 ' </Snippet1>
