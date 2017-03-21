    Private Sub dataGridView1_Sorted(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles dataGridView1.Sorted

        Me.dataGridView1.FirstDisplayedCell = Me.dataGridView1.CurrentCell

    End Sub