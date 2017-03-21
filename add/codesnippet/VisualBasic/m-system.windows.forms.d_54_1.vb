    Private Sub selectedCellsButton_Click( _
        ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles selectedCellsButton.Click

        Dim selectedCellCount As Integer = _
            dataGridView1.GetCellCount(DataGridViewElementStates.Selected)

        If selectedCellCount > 0 Then

            If dataGridView1.AreAllCellsSelected(True) Then

                MessageBox.Show("All cells are selected", "Selected Cells")

            Else

                Dim sb As New System.Text.StringBuilder()

                Dim i As Integer
                For i = 0 To selectedCellCount - 1

                    sb.Append("Row: ")
                    sb.Append(dataGridView1.SelectedCells(i).RowIndex _
                        .ToString())
                    sb.Append(", Column: ")
                    sb.Append(dataGridView1.SelectedCells(i).ColumnIndex _
                        .ToString())
                    sb.Append(Environment.NewLine)

                Next i

                sb.Append("Total: " + selectedCellCount.ToString())
                MessageBox.Show(sb.ToString(), "Selected Cells")

            End If

        End If

    End Sub