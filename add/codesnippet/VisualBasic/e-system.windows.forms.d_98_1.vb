    Private Sub ValidateByRow(ByVal sender As Object, _
        ByVal data As DataGridViewCellCancelEventArgs) _
        Handles songsDataGridView.RowValidating

        Dim row As DataGridViewRow = _
            songsDataGridView.Rows(data.RowIndex)
        Dim trackCell As DataGridViewCell = _
            row.Cells(songsDataGridView.Columns("Track").Index)
        Dim dateCell As DataGridViewCell = _
            row.Cells(songsDataGridView.Columns("Release Date").Index)
        data.Cancel = Not (IsTrackGood(trackCell) _
            AndAlso IsDateGood(dateCell))
    End Sub

    Private Function IsTrackGood(ByRef cell As DataGridViewCell) As Boolean

        If cell.Value.ToString().Length = 0 Then
            cell.ErrorText = "Please enter a track"
            songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                "Please enter a track"
            Return False
        ElseIf cell.Value.ToString().Equals("0") Then
            cell.ErrorText = "Zero is not a valid track"
            songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                "Zero is not a valid track"
            Return False
        ElseIf Not Integer.TryParse( _
            cell.Value.ToString(), New Integer()) Then
            cell.ErrorText = "A Track must be a number"
            songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                "A Track must be a number"
            Return False
        End If
        Return True
    End Function

    Private Function IsDateGood(ByRef cell As DataGridViewCell) As Boolean

        If cell.Value Is Nothing Then
            cell.ErrorText = "Missing date"
            songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                "Missing date"
            Return False
        Else
            Try
                DateTime.Parse(cell.Value.ToString())
            Catch ex As FormatException

                cell.ErrorText = "Invalid format"
                songsDataGridView.Rows(cell.RowIndex).ErrorText = _
                    "Invalid format"

                Return False
            End Try
        End If
        Return True
    End Function