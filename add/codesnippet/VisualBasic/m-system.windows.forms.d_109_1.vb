    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim myGrid As DataGrid = CType(sender, DataGrid)
        Dim myCell As DataGridCell = myGrid.CurrentCell
        Console.WriteLine(myCell.ToString)
    End Sub
