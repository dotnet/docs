    ' Hide a band of cells.
    Private Sub Button6_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button6.Click

        Dim band As DataGridViewBand = dataGridView.Rows(3)
        band.Visible = False
    End Sub