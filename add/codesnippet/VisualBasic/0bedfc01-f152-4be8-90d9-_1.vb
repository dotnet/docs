    ' When the mouse hovers over Button3, two reversible lines are drawn
    ' using the corner coordinates of Button3, which are first 
    ' converted to screen coordinates.
    Private Sub Button3_MouseHover(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button3.MouseHover

        ControlPaint.DrawReversibleLine(Button3.PointToScreen(New Point(0, 0)), _
        Button3.PointToScreen(New Point(Button3.ClientRectangle.Right, _
            Button3.ClientRectangle.Bottom)), SystemColors.Control)
        ControlPaint.DrawReversibleLine(Button3.PointToScreen( _
            New Point(Button3.ClientRectangle.Right, Button3.ClientRectangle.Top)), _
           Button3.PointToScreen(New Point _
                (Button1.ClientRectangle.Left, Button3.ClientRectangle.Bottom)), _
                SystemColors.Control)
    End Sub

    ' When the mouse moves from Button3, the reversible lines are 
    ' erased by using the same coordinates as are used in the
    ' Button3_MouseHover method.
    Private Sub Button3_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button3.MouseLeave

        ControlPaint.DrawReversibleLine(Button3.PointToScreen(New Point(0, 0)), _
        Button3.PointToScreen(New Point(Button3.ClientRectangle.Right, _
            Button3.ClientRectangle.Bottom)), SystemColors.Control)
        ControlPaint.DrawReversibleLine(Button3.PointToScreen( _
            New Point(Button3.ClientRectangle.Right, Button3.ClientRectangle.Top)), _
           Button3.PointToScreen(New Point(Button3.ClientRectangle.Left, _
           Button3.ClientRectangle.Bottom)), SystemColors.Control)
    End Sub