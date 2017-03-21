    ' When the mouse hovers over Button2, its ClientRectangle is filled.
    Private Sub Button2_MouseHover(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button2.MouseHover

        Dim senderControl As Control = CType(sender, Control)
        Dim screenRectangle As Rectangle = _
            senderControl.RectangleToScreen(senderControl.ClientRectangle)
        ControlPaint.FillReversibleRectangle(screenRectangle, _
            senderControl.BackColor)
    End Sub


    ' When the mouse leaves Button2, its ClientRectangle is cleared by
    ' calling the FillReversibleRectangle method again.
    Private Sub Button2_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button2.MouseLeave

        Dim senderControl As Control = CType(sender, Control)
        Dim screenRectangle As Rectangle = _
            senderControl.RectangleToScreen(senderControl.ClientRectangle)
        ControlPaint.FillReversibleRectangle(screenRectangle, _
            senderControl.BackColor)
    End Sub