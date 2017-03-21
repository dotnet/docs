    ' Set minimum height.
    Private Sub Button4_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        Dim secondRow As Integer = 1
        Dim row As DataGridViewRow = dataGridView.Rows(secondRow)
        row.MinimumHeight = 40
    End Sub