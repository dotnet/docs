    Private Sub RenderText7(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "This is some text.", _
            Me.Font, New Point(10, 10), Color.White, Color.SteelBlue, _
            TextFormatFlags.Default)

    End Sub
