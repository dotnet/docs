    Private Sub CreateColumns()

        Dim imageColumn As DataGridViewImageColumn
        Dim columnCount As Integer = 0
        Do
            Dim unMarked As Bitmap = blank
            imageColumn = New DataGridViewImageColumn()

            ' Add twice the padding for the left and 
            ' right sides of the cell.
            imageColumn.Width = x.Width + 2 * bitmapPadding + 1

            imageColumn.Image = unMarked
            imageColumn.ImageLayout = DataGridViewImageCellLayout.NotSet
            imageColumn.Description = "default image layout"
            dataGridView1.Columns.Add(imageColumn)
            columnCount = columnCount + 1
        Loop While columnCount < 3
    End Sub