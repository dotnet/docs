    ' Change the text in the column header.
    Private Sub Button9_Click(ByVal sender As Object, _
        ByVal args As EventArgs) Handles Button9.Click

        For Each column As DataGridViewColumn _
            In dataGridView.Columns

            column.HeaderText = String.Concat("Column ", _
                column.Index.ToString)
        Next
    End Sub