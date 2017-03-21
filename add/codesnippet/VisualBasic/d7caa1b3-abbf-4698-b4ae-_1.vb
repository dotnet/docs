    Private Sub RenderText3(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Regular Text", Me.Font, _
            New Point(10, 10), Color.Red, Color.PowderBlue)

    End Sub
