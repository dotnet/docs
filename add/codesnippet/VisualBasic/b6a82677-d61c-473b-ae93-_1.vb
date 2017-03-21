    Private Sub CreateARectangleFromLTRB(ByVal e As PaintEventArgs)
        Dim myRectangle As Rectangle = Rectangle.FromLTRB(40, 40, 140, 240)
        e.Graphics.DrawRectangle(SystemPens.ControlText, myRectangle)
    End Sub