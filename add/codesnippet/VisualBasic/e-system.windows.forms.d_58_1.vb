    Private Sub CellValueChanged(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellValueChanged

        ' Update the balance column whenever the values of any cell changes.
        UpdateBalance()
    End Sub

    Private Sub RowsRemoved(ByVal sender As Object, _
        ByVal e As DataGridViewRowsRemovedEventArgs) _
        Handles DataGridView1.RowsRemoved

        ' Update the balance column whenever rows are deleted.
        UpdateBalance()
    End Sub

    Private Sub UpdateBalance()
        Dim counter As Integer
        Dim balance As Integer
        Dim deposit As Integer
        Dim withdrawal As Integer

        ' Iterate through the rows, skipping the Starting Balance Row.
        For counter = 1 To (DataGridView1.Rows.Count - 2)
            deposit = 0
            withdrawal = 0
            balance = Integer.Parse(DataGridView1.Rows(counter - 1) _
                .Cells("Balance").Value.ToString())

            If Not DataGridView1.Rows(counter) _
                .Cells("Deposits").Value Is Nothing Then

                ' Verify that the cell value is not an empty string.
                If Not DataGridView1.Rows(counter) _
                    .Cells("Deposits").Value.ToString().Length = 0 Then
                    deposit = Integer.Parse(DataGridView1.Rows(counter) _
                        .Cells("Deposits").Value.ToString())
                End If
            End If

            If Not DataGridView1.Rows(counter) _
                .Cells("Withdrawals").Value Is Nothing Then
                If Not DataGridView1.Rows(counter) _
                    .Cells("Withdrawals").Value.ToString().Length = 0 Then
                    withdrawal = Integer.Parse(DataGridView1.Rows(counter) _
                        .Cells("Withdrawals").Value.ToString())
                End If
            End If

            DataGridView1.Rows(counter).Cells("Balance").Value = _
                (balance + deposit + withdrawal).ToString()
        Next
    End Sub