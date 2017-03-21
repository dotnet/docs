    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting
        ' If the column is the Artist column, check the
        ' value.
        If Me.dataGridView1.Columns(e.ColumnIndex).Name _
            = "Artist" Then
            If e.Value IsNot Nothing Then

                ' Check for the string "pink" in the cell.
                Dim stringValue As String = _
                CType(e.Value, String)
                stringValue = stringValue.ToLower()
                If ((stringValue.IndexOf("pink") > -1)) Then
                    e.CellStyle.BackColor = Color.Pink
                End If

            End If
        ElseIf Me.dataGridView1.Columns(e.ColumnIndex).Name _
            = "Release Date" Then
            ShortFormDateFormat(e)
        End If
    End Sub

    'Even though the date internaly stores the year as YYYY, using formatting, the
    'UI can have the format in YY.  
    Private Shared Sub ShortFormDateFormat(ByVal formatting As DataGridViewCellFormattingEventArgs)
        If formatting.Value IsNot Nothing Then
            Try
                Dim dateString As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim theDate As Date = DateTime.Parse(formatting.Value.ToString())

                dateString.Append(theDate.Month)
                dateString.Append("/")
                dateString.Append(theDate.Day)
                dateString.Append("/")
                dateString.Append(theDate.Year.ToString().Substring(2))
                formatting.Value = dateString.ToString()
                formatting.FormattingApplied = True
            Catch notInDateFormat As FormatException
                ' Set to false in case there are other handlers interested trying to
                ' format this DataGridViewCellFormattingEventArgs instance.
                formatting.FormattingApplied = False
            End Try
        End If
    End Sub