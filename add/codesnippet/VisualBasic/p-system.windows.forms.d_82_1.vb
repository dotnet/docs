Private Sub ScrollGrid(ByVal myGrid As DataGrid)
    If myGrid.FirstVisibleColumn > 5 Then
       myGrid.CurrentCell = New DataGridCell( 1,1 )
    End If
 End Sub
    