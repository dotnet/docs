    Private Sub dataGridView1_CellValidating(ByVal sender As Object, _
        ByVal e As DataGridViewCellValidatingEventArgs) _
        Handles dataGridView1.CellValidating

        Dim headerText As String = _
            dataGridView1.Columns(e.ColumnIndex).HeaderText

        ' Abort validation if cell is not in the CompanyName column.
        If Not headerText.Equals("CompanyName") Then Return

        ' Confirm that the cell is not empty.
        If (String.IsNullOrEmpty(e.FormattedValue.ToString())) Then
            dataGridView1.Rows(e.RowIndex).ErrorText = _
                "Company Name must not be empty"
            e.Cancel = True
        End If
    End Sub

    Private Sub dataGridView1_CellEndEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dataGridView1.CellEndEdit

        ' Clear the row error in case the user presses ESC.   
        dataGridView1.Rows(e.RowIndex).ErrorText = String.Empty

    End Sub