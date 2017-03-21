    ' Set the vertical edge.
    Private Sub Button7_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button7.Click

        Dim thirdColumn As Integer = 2
        Dim column As DataGridViewColumn = _
            dataGridView.Columns(thirdColumn)
        column.DividerWidth = 10

    End Sub