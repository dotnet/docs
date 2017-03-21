    Private Sub dataGridView1_CellValidating(ByVal sender As Object, _
        ByVal e _
        As DataGridViewCellValidatingEventArgs) _
        Handles dataGridView1.CellValidating

        Me.dataGridView1.Rows(e.RowIndex).ErrorText = ""
        Dim newInteger As Integer

        ' Don't try to validate the 'new row' until finished 
        ' editing since there
        ' is not any point in validating its initial value.
        If dataGridView1.Rows(e.RowIndex).IsNewRow Then Return
        If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) _
            OrElse newInteger < 0 Then

            e.Cancel = True
            Me.dataGridView1.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"

        End If
    End Sub