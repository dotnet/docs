Public Class ShapePointToScreen
    ' <Snippet1>
    Public isDrag As Boolean = True
    Public theRectangle As System.Drawing.Rectangle

    Private Sub Form1_MouseMove(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.MouseEventArgs
      ) Handles RectangleShape1.MouseMove

        ' If the mouse is being dragged, undraw and redraw the rectangle
        ' while the mouse moves.
        If (isDrag) Then

            ' Hide the previous rectangle by calling the
            ' DrawReversibleFrame method, using the same parameters.
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, 
              FrameStyle.Dashed)

            ' Calculate the endpoint and dimensions for the new rectangle, 
            ' again by using the PointToScreen method.
            Dim startPoint As Point = New Point(RectangleShape1.Width, 
             RectangleShape1.Height)
            Dim endPoint As Point = RectangleShape1.PointToScreen(New Point(e.X, e.Y))
            Dim width As Integer = endPoint.X - startPoint.X
            Dim height As Integer = endPoint.Y - startPoint.Y
            theRectangle = New Rectangle(startPoint.X, startPoint.Y, 
             width, height)

            ' Draw the new rectangle by calling DrawReversibleFrame again.  
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, 
              FrameStyle.Dashed)
        End If
    End Sub

    Private Sub Form1_MouseUp() Handles RectangleShape1.MouseUp

        ' If the MouseUp event occurs, the user is not dragging.
        isDrag = False
        ' Draw the rectangle to be evaluated. Set a dashed frame style 
        ' by using the FrameStyle enumeration.
        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, 
          FrameStyle.Dashed)
        ' Find out which controls intersect the rectangle, and change
        ' their colors.
        ' The method uses the RectangleToScreen method to convert the 
        ' control's client coordinates to screen coordinates.
        Dim controlRectangle As Rectangle

        controlRectangle = RectangleShape1.RectangleToScreen(
           RectangleShape1.ClientRectangle)
        If controlRectangle.IntersectsWith(theRectangle) Then
            RectangleShape1.BackColor = Color.BurlyWood
        End If

        ' Reset the rectangle.
        theRectangle = New Rectangle(0, 0, 0, 0)
    End Sub
    ' </Snippet1>
End Class
