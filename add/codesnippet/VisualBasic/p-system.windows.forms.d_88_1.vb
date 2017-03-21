    ' Display NullValue for cell values equal to DataSourceNullValue.
    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting

        Dim value As String = TryCast(e.Value, String)
        If value IsNot Nothing And _
            value.Equals(e.CellStyle.DataSourceNullValue) Then

            e.Value = e.CellStyle.NullValue
            e.FormattingApplied = True

        End If

    End Sub