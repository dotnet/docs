    Private Sub selectedColumnsButton_Click( _
        ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles selectedColumnsButton.Click

        Dim selectedColumnCount As Integer = dataGridView1.Columns _
            .GetColumnCount(DataGridViewElementStates.Selected)

        If selectedColumnCount > 0 Then

            Dim sb As New System.Text.StringBuilder()

            Dim i As Integer
            For i = 0 To selectedColumnCount - 1

                sb.Append("Column: ")
                sb.Append(dataGridView1.SelectedColumns(i).Index.ToString())
                sb.Append(Environment.NewLine)

            Next i

            sb.Append("Total: " + selectedColumnCount.ToString())
            MessageBox.Show(sb.ToString(), "Selected Columns")

        End If

    End Sub