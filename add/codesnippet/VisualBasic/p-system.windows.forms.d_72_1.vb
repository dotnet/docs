    Private Sub getCurrentCellButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles getCurrentCellButton.Click

        Dim msg As String = String.Format("Row: {0}, Column: {1}", _
            dataGridView1.CurrentCell.RowIndex, _
            dataGridView1.CurrentCell.ColumnIndex)
        MessageBox.Show(msg, "Current Cell")

    End Sub