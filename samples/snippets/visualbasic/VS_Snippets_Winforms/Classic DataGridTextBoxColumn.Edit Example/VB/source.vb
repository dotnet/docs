Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

 ' <Snippet1>
Public Class Form1
   Inherits Form
   Protected dataGrid1 As DataGrid
   Protected myDataSet As DataSet
    
   
    Private Sub dataGrid1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Use the HitTest method to get a HitTestInfo object.
        Dim hi As DataGrid.HitTestInfo
        Dim grid As DataGrid = CType(sender, DataGrid)
        hi = grid.HitTest(e.X, e.Y)
        ' Test if the clicked area was a cell.
        If hi.Type = DataGrid.HitTestType.Cell Then
            ' If it's a cell, get the GridTable and CurrencyManager of the
            ' clicked table.         
            Dim dgt As DataGridTableStyle = dataGrid1.TableStyles(0)
            Dim cm As CurrencyManager = CType _
            (Me.BindingContext(myDataSet.Tables(dgt.MappingName)), _
            CurrencyManager)
            ' Get the Rectangle of the clicked cell.
            Dim cellRect As Rectangle = _
            grid.GetCellBounds(hi.Row, hi.Column)
            ' Get the clicked DataGridTextBoxColumn.
            Dim gridCol As MyGridColumn = CType _
            (dgt.GridColumnStyles(hi.Column), MyGridColumn)
            ' Edit the value.
            gridCol.EditCol(cm, hi.Row, cellRect, False, "New Text", True)
        End If
    End Sub
End Class 

Public Class MyGridColumn
Inherits DataGridTextBoxColumn
   Public Sub EditCol(cm As CurrencyManager , rowNum As integer , _
   cellRect As Rectangle , bReadOnly As Boolean , _
   myString As String , isVisible As Boolean )
      me.Edit(cm, rowNum, cellRect, bReadOnly, myString, isVisible)
   End Sub
End Class

 ' </Snippet1>
