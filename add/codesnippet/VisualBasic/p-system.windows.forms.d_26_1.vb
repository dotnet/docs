    ' Make the the entire DataGridView read only.
    Private Sub Button8_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button8.Click

        For Each band As DataGridViewBand In dataGridView.Columns
            band.ReadOnly = True
        Next
    End Sub