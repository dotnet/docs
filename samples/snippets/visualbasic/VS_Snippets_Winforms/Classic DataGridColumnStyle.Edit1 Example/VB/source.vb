Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


    ' <Snippet1>
Public Class Form1
   Inherits Form

   Protected myDataSet As DataSet

   Shared Sub Main()
   End Sub
    
    Private Sub dataGrid1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Use the HitTest method to get a HitTestInfo object.
        Dim hi As System.Windows.Forms.DataGrid.HitTestInfo
        Dim grid As DataGrid = CType(sender, DataGrid)
        hi = grid.HitTest(e.X, e.Y)
        ' Test if the clicked area was a cell.
        If hi.Type = DataGrid.HitTestType.Cell Then
            ' If it's a cell, get the GridTable and CurrencyManager of the
            ' clicked table.         
            Dim dgt As DataGridTableStyle = grid.TableStyles(0)
            Dim myCurrencyManager As CurrencyManager = _
            CType(Me.BindingContext _
            (myDataSet.Tables(dgt.MappingName)), CurrencyManager)
            ' Get the Rectangle of the clicked cell.
            Dim cellRect As Rectangle
            cellRect = grid.GetCellBounds(hi.Row, hi.Column)
            ' Get the clicked DataGridTextBoxColumn.
            Dim gridCol As MyColumnStyle = CType(dgt.GridColumnStyles _
            (hi.Column), MyColumnStyle)
            ' Edit the value.
            gridCol.EditVal(myCurrencyManager, hi.Row, cellRect, False, "New Text")
        End If
    End Sub
End Class 

Public Class MyColumnStyle
   Inherits DataGridTextBoxColumn
   Public Sub EditVal(cm As CurrencyManager, row As Integer, _
   rec As Rectangle, bReadOnly As Boolean, text As String)
      MyBase.Edit(cm, row, rec, bReadOnly, text)
   End Sub
End Class
    ' </Snippet1>
