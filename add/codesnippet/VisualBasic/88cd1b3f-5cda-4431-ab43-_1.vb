    Private Sub RenderText1(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Regular Text", _
            Me.Font, New Point(10, 10), SystemColors.ControlText)

    End Sub

