    ' Set a thick horizontal edge.
    Private Sub Button7_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button7.Click

        Dim secondRow As Integer = 1
        Dim row As DataGridViewRow = dataGridView.Rows(secondRow)
        row.DividerHeight = 10

    End Sub