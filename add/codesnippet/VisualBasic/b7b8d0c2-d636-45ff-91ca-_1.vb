    Private Sub RenderText2(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Regular Text", _
            Me.Font, New Rectangle(10, 10, 100, 100), _
            SystemColors.ControlText)

    End Sub

