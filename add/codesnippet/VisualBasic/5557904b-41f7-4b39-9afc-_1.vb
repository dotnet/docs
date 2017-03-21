    Private Sub RenderText4(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Regular Text.", _
            Me.Font, New Rectangle(10, 10, 70, 70), _
            SystemColors.ControlText, SystemColors.ControlDark)

    End Sub
