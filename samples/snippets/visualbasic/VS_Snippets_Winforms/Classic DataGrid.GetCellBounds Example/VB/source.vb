Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    Protected myDataSet As DataSet
    
    ' <Snippet1>
    Private Sub dataGrid1_MouseDown _
(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Use the HitTest method to get a HitTestInfo object.
        Dim hi As System.Windows.Forms.DataGrid.HitTestInfo
        Dim grid As DataGrid = CType(sender, DataGrid)
        hi = grid.HitTest(e.X, e.Y)
        ' Test if the clicked area was a cell.
        If hi.Type = DataGrid.HitTestType.Cell Then
            ' If it's a cell, get the GridTable and CurrencyManager of the
            ' clicked table.         
            Dim dgt As DataGridTableStyle = dataGrid1.TableStyles(0)
            Dim myCurrencyManager As CurrencyManager = _
            CType(Me.BindingContext _
            (myDataSet.Tables(dataGrid1.DataMember)), CurrencyManager)
            ' Get the Rectangle of the clicked cell.
            Dim cellRect As Rectangle
            cellRect = grid.GetCellBounds(hi.Row, hi.Column)
            ' Get the clicked DataGridTextBoxColumn.
            Dim gridCol As DataGridTextBoxColumn = _
            CType(dgt.GridColumnStyles(hi.Column), DataGridTextBoxColumn)
            ' Insert code to dit the value.
        End If
    End Sub
    ' </Snippet1>
End Class 'Form1 

