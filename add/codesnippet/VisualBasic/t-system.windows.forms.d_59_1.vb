    ' Sets the ToolTip text for cells in the Rating column.
    Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting

        If e.ColumnIndex = Me.dataGridView1.Columns("Rating").Index _
            AndAlso (e.Value IsNot Nothing) Then

            With Me.dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If e.Value.Equals("*") Then
                    .ToolTipText = "very bad"
                ElseIf e.Value.Equals("**") Then
                    .ToolTipText = "bad"
                ElseIf e.Value.Equals("***") Then
                    .ToolTipText = "good"
                ElseIf e.Value.Equals("****") Then
                    .ToolTipText = "very good"
                End If

            End With

        End If

    End Sub 'dataGridView1_CellFormatting