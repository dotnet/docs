    ' Handle the Form's Paint event to draw a 3D three-dimensional 
    ' raised border just inside the border of the frame.
    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As PaintEventArgs) Handles MyBase.Paint

        Dim borderRectangle As Rectangle = Me.ClientRectangle
        borderRectangle.Inflate(-10, -10)
        ControlPaint.DrawBorder3D(e.Graphics, borderRectangle, _
            Border3DStyle.Raised)
    End Sub