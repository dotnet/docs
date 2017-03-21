    ' This method draws a focus rectangle on Button2 using the 
    ' handle and client rectangle of Button2.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        ControlPaint.DrawFocusRectangle(Graphics.FromHwnd(Button2.Handle), _
        Button2.ClientRectangle)
    End Sub