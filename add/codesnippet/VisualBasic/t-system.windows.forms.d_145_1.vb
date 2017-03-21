    ' Handling CellParsing allows one to accept user input, then map it to a different
    ' internal representation.
    Private Sub dataGridView1_CellParsing(ByVal sender As Object, _
        ByVal e As DataGridViewCellParsingEventArgs) _
        Handles dataGridView1.CellParsing

        If Me.dataGridView1.Columns(e.ColumnIndex).Name = _
            "Release Date" Then
            If e IsNot Nothing Then
                If e.Value IsNot Nothing Then
                    Try
                        ' Map what the user typed into UTC.
                        e.Value = _
                        DateTime.Parse(e.Value.ToString()).ToUniversalTime()
                        ' Set the ParsingApplied property to 
                        ' Show the event is handled.
                        e.ParsingApplied = True

                    Catch ex As FormatException
                        ' Set to false in case another CellParsing handler
                        ' wants to try to parse this DataGridViewCellParsingEventArgs instance.
                        e.ParsingApplied = False
                    End Try
                End If
            End If
        End If
    End Sub