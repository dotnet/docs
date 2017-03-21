Private Sub GetSelectedIndex(ByVal myGrid As DataGrid)
    Console.WriteLine(myGrid.CurrentRowIndex)
 End Sub
 
 Private Sub SetSelectedIndex(ByVal myGrid As DataGrid, ByVal selIndex As Integer)
    myGrid.CurrentRowIndex= selIndex
 End Sub
 