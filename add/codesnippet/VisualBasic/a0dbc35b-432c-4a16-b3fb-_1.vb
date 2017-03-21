    Private Sub RenderText5(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Some text.", _
        Me.Font, New Point(10, 10), SystemColors.ControlText, _
        TextFormatFlags.Bottom)

    End Sub
