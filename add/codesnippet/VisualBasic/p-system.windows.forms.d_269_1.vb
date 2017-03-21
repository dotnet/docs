    Private Sub UpdateLabelText()
        Dim WithdrawalTotal As Integer = 0
        Dim DepositTotal As Integer = 0
        Dim SelectedCellTotal As Integer = 0
        Dim counter As Integer

        ' Iterate through all the rows and sum up the appropriate columns.
        For counter = 0 To (DataGridView1.Rows.Count - 1)
            If Not DataGridView1.Rows(counter) _
                .Cells("Withdrawals").Value Is Nothing Then

                If Not DataGridView1.Rows(counter) _
                    .Cells("Withdrawals").Value.ToString().Length = 0 Then

                    WithdrawalTotal += _
                        Integer.Parse(DataGridView1.Rows(counter) _
                        .Cells("Withdrawals").Value.ToString())
                End If
            End If

            If Not DataGridView1.Rows(counter) _
                .Cells("Deposits").Value Is Nothing Then

                If Not DataGridView1.Rows(counter) _
                    .Cells("Deposits").Value.ToString().Length = 0 Then

                    DepositTotal += _
                        Integer.Parse(DataGridView1.Rows(counter) _
                        .Cells("Deposits").Value.ToString())
                End If
            End If
        Next

        ' Iterate through the SelectedCells collection and sum up the values.
        For counter = 0 To (DataGridView1.SelectedCells.Count - 1)
            If DataGridView1.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been commited,
                ' use the modified value.
                If (DataGridView1.IsCurrentCellDirty = True) Then

                    value = DataGridView1.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridView1.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                If value IsNot Nothing Then

                    ' Ignore cells in the Description column.
                    If Not DataGridView1.SelectedCells(counter).ColumnIndex = _
                        DataGridView1.Columns("Description").Index Then

                        If Not value.Length = 0 Then
                            SelectedCellTotal += Integer.Parse(value)
                        End If
                    End If
                End If
            End If

        Next

        ' Set the labels to reflect the current state of the DataGridView.
        Label1.Text = "Withdrawals Total: " & WithdrawalTotal.ToString()
        Label2.Text = "Deposits Total: " & DepositTotal.ToString()
        Label3.Text = "Selected Cells Total: " & SelectedCellTotal.ToString()
        Label4.Text = "Total entries: " & DataGridView1.RowCount.ToString()
    End Sub