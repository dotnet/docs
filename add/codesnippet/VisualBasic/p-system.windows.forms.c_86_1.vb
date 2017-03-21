Private Sub ResizeForm()
   ' Enable auto-scrolling for the form.
   Me.AutoScroll = True
   
   ' Resize the form.
   Dim r As Rectangle = Me.ClientRectangle
   ' Subtract 100 pixels from each side of the Rectangle.
   r.Inflate(- 100, - 100)
   Me.Bounds = Me.RectangleToScreen(r)
   
   ' Make sure button2 is visible.
   Me.ScrollControlIntoView(button2)
End Sub