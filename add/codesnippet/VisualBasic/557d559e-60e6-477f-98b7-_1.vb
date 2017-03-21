    ' Handle the Button1 object's Paint Event to create a CaptionButton.
    Private Sub Button1_Paint(ByVal sender As Object, _
        ByVal e As PaintEventArgs) Handles Button1.Paint

        ' Draw a CaptionButton control using the ClientRectangle 
        ' property of Button1. Make the button a Help button 
        ' with a normal state.
        ControlPaint.DrawCaptionButton(e.Graphics, Button1.ClientRectangle, _
            CaptionButton.Help, ButtonState.Normal)
    End Sub