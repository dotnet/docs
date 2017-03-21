    ' Set the width.
    Private Sub Button5_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button5.Click

        Dim column As DataGridViewColumn = dataGridView.Columns(0)
        column.Width = 60
    End Sub