    ' Freeze the first row.
    Private Sub Button4_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        FreezeBand(dataGridView.Rows(0))
    End Sub

    Private Sub FreezeColumn(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button5.Click

        FreezeBand(dataGridView.Columns(1))
    End Sub

    Private Shared Sub FreezeBand(ByVal band As DataGridViewBand)

        band.Frozen = True
        Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
        style.BackColor = Color.WhiteSmoke
        band.DefaultCellStyle = style

    End Sub