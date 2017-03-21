    ' Set row labels.
    Private Sub Button6_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button6.Click

        Dim rowNumber As Integer = 1
        For Each row As DataGridViewRow In dataGridView.Rows
            If row.IsNewRow Then Continue For
            row.HeaderCell.Value = "Row " & rowNumber
            rowNumber = rowNumber + 1
        Next
        dataGridView.AutoResizeRowHeadersWidth( _
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
    End Sub