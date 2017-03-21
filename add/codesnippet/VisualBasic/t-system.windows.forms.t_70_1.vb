    Private Sub RenderText6(ByVal e As PaintEventArgs)
        Dim flags As TextFormatFlags = TextFormatFlags.Bottom Or _
            TextFormatFlags.EndEllipsis
        TextRenderer.DrawText(e.Graphics, _
        "This is some text that will be clipped at the end.", _
        Me.Font, New Rectangle(10, 10, 100, 50), SystemColors.ControlText, flags)

    End Sub
