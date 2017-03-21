    Private Sub selectedRowsButton_Click( _
        ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles selectedRowsButton.Click

        Dim selectedRowCount As Integer = _
            dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If selectedRowCount > 0 Then

            Dim sb As New System.Text.StringBuilder()

            Dim i As Integer
            For i = 0 To selectedRowCount - 1

                sb.Append("Row: ")
                sb.Append(dataGridView1.SelectedRows(i).Index.ToString())
                sb.Append(Environment.NewLine)

            Next i

            sb.Append("Total: " + selectedRowCount.ToString())
            MessageBox.Show(sb.ToString(), "Selected Rows")

        End If

    End Sub