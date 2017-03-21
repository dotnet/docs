    ' Set height.
    Private Sub Button5_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button5.Click

        Dim row As DataGridViewRow = dataGridView.Rows(0)
        row.Height = 15
    End Sub