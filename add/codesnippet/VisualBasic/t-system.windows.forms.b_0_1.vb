        Private Sub button2_Click(sender As Object, e As System.EventArgs)
            ' Draws a flat button on button1.
            ControlPaint.DrawButton(System.Drawing.Graphics.FromHwnd(button1.Handle), 0, 0, button1.Width, button1.Height, ButtonState.Flat)
        End Sub 'button2_Click