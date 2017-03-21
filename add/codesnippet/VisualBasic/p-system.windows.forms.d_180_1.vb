    Private Sub PostRowCreation()
        SetBandColor(dataGridView.Columns(0), Color.CadetBlue)
        SetBandColor(dataGridView.Rows(1), Color.Coral)
        SetBandColor(dataGridView.Columns(2), Color.DodgerBlue)
    End Sub

    Private Shared Sub SetBandColor(ByVal band As DataGridViewBand, _
        ByVal color As Color)
        band.Tag = color
    End Sub

    ' Color the bands by the value stored in their tag.
    Private Sub Button9_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button9.Click

        For Each band As DataGridViewBand In dataGridView.Columns
            If band.Tag IsNot Nothing Then
                band.DefaultCellStyle.BackColor = _
                    CType(band.Tag, Color)
            End If
        Next

        For Each band As DataGridViewBand In dataGridView.Rows
            If band.Tag IsNot Nothing Then
                band.DefaultCellStyle.BackColor = _
                    CType(band.Tag, Color)
            End If
        Next
    End Sub