    Private Sub dataGridView1_RowEnter(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.RowEnter

        Dim i As Integer
        For i = 0 To dataGridView1.Rows(e.RowIndex).Cells.Count - 1
            dataGridView1(i, e.RowIndex).Style _
                .BackColor = Color.Yellow
        Next i

    End Sub

    Private Sub dataGridView1_RowLeave(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.RowLeave

        Dim i As Integer
        For i = 0 To dataGridView1.Rows(e.RowIndex).Cells.Count - 1
            dataGridView1(i, e.RowIndex).Style _
                .BackColor = Color.Empty
        Next i

    End Sub