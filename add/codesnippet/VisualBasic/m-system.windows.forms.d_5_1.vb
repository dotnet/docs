
 Private Sub NavToGrid(ByVal myGrid As DataGrid)
    ' Presumes a relationship named OrderDetails exists.
    myGrid.NavigateTo( 2, "OrderDetails" )
 End Sub
       