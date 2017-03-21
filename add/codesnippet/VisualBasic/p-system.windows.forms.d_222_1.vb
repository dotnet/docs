    ' Draws column headers.
    Private Sub listView1_DrawColumnHeader(ByVal sender As Object, _
        ByVal e As DrawListViewColumnHeaderEventArgs) _
        Handles listView1.DrawColumnHeader

        Dim sf As New StringFormat()
        Try

            ' Store the column text alignment, letting it default
            ' to Left if it has not been set to Center or Right.
            Select Case e.Header.TextAlign
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
            End Select

            ' Draw the standard header background.
            e.DrawBackground()

            ' Draw the header text.
            Dim headerFont As New Font("Helvetica", 10, FontStyle.Bold)
            Try
                e.Graphics.DrawString(e.Header.Text, headerFont, _
                    Brushes.Black, e.Bounds, sf)
            Finally
                headerFont.Dispose()
            End Try

        Finally
            sf.Dispose()
        End Try

    End Sub