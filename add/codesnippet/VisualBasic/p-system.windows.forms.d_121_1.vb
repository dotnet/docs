    ' Give cheescake excellent rating.
    Private Sub Button8_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button8.Click

        UpdateStars(dataGridView.Rows(4), "******************")
    End Sub

    Private ratingColumn As Integer = 3

    Private Sub UpdateStars(ByVal row As DataGridViewRow, _
        ByVal stars As String)

        row.Cells(ratingColumn).Value = stars

        ' Resize the column width to account for the new value.
        row.DataGridView.AutoResizeColumn(ratingColumn, _
            DataGridViewAutoSizeColumnMode.DisplayedCells)

    End Sub