    Private Sub Stretch(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button3.Click

        For Each column As DataGridViewImageColumn _
            In dataGridView1.Columns
            column.ImageLayout = DataGridViewImageCellLayout.Stretch
            column.Description = "Stretched image layout"
        Next
    End Sub

    Private Sub ZoomToImage(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button4.Click

        For Each column As DataGridViewImageColumn _
            In dataGridView1.Columns
            column.ImageLayout = DataGridViewImageCellLayout.Zoom
            column.Description = "Zoomed image layout"
        Next
    End Sub

    Private Sub NormalImage(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button5.Click

        For Each column As DataGridViewImageColumn _
            In dataGridView1.Columns
            column.ImageLayout = DataGridViewImageCellLayout.Normal
            column.Description = "Normal image layout"
        Next
    End Sub