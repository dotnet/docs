    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, _
        ByVal e As DataGridViewEditingControlShowingEventArgs) _
        Handles dataGridView1.EditingControlShowing

        e.CellStyle.BackColor = Color.Aquamarine

    End Sub