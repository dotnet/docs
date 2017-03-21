    Private Sub RenderText8(ByVal e As PaintEventArgs)
        Dim flags As TextFormatFlags = _
            TextFormatFlags.Bottom Or TextFormatFlags.WordBreak
        TextRenderer.DrawText(e.Graphics, _
            "This is some text that will display on multiple lines.", _
            Me.Font, New Rectangle(10, 10, 100, 50), _
            SystemColors.ControlText, SystemColors.ControlDark, flags)

    End Sub

