    Private Sub dataGridView1_CellValidating(ByVal sender As Object, _
        ByVal e As _
        DataGridViewCellValidatingEventArgs) _
        Handles dataGridView1.CellValidating

        Dim column As DataGridViewColumn = _
            dataGridView1.Columns(e.ColumnIndex)

        If column.Name = "Track" Then
            CheckTrack(e)
        ElseIf column.Name = "Release Date" Then
            CheckDate(e)
        End If
    End Sub

    Private Shared Sub CheckTrack(ByVal newValue As DataGridViewCellValidatingEventArgs)
        If String.IsNullOrEmpty(newValue.FormattedValue.ToString()) Then
            NotifyUserAndForceRedo("Please enter a track", newValue)
        ElseIf Not Integer.TryParse( _
            newValue.FormattedValue.ToString(), New Integer()) Then
            NotifyUserAndForceRedo("A Track must be a number", newValue)
        ElseIf Integer.Parse(newValue.FormattedValue.ToString()) < 1 Then
            NotifyUserAndForceRedo("Not a valid track", newValue)
        End If
    End Sub

    Private Shared Sub NotifyUserAndForceRedo(ByVal errorMessage As String, ByVal newValue As DataGridViewCellValidatingEventArgs)
        MessageBox.Show(errorMessage)
        newValue.Cancel = True
    End Sub

    Private Sub CheckDate(ByVal newValue As DataGridViewCellValidatingEventArgs)
        Try
            DateTime.Parse(newValue.FormattedValue.ToString()).ToLongDateString()
            AnnotateCell(String.Empty, newValue)
        Catch ex As FormatException
            AnnotateCell("You did not enter a valid date.", newValue)
        End Try
    End Sub

    Private Sub AnnotateCell(ByVal errorMessage As String, _
        ByVal editEvent As DataGridViewCellValidatingEventArgs)

        Dim cell As DataGridViewCell = _
            dataGridView1.Rows(editEvent.RowIndex).Cells( _
                editEvent.ColumnIndex)
        cell.ErrorText = errorMessage
    End Sub