Private Sub DataGrid1_CurrentCellChange(ByVal sender As Object, ByVal e As EventArgs)
    Dim rect As Rectangle
    rect = DataGrid1.GetCurrentCellBounds()
    Console.WriteLine(rect.ToString)
 End Sub
 