    ' The following three methods will draw a rectangle and allow 
    ' the user to use the mouse to resize the rectangle.  If the 
    ' rectangle intersects a control's client rectangle, the 
    ' control's color will change.

    Dim isDrag As Boolean = False
    Dim theRectangle As New rectangle(New Point(0, 0), New Size(0, 0))
    Dim startPoint As Point

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As _
        System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        ' Set the isDrag variable to true and get the starting point 
        ' by using the PointToScreen method to convert form coordinates to
        ' screen coordinates.
        If (e.Button = MouseButtons.Left) Then
            isDrag = True
        End If

        Dim control As Control = CType(sender, Control)

        ' Calculate the startPoint by using the PointToScreen 
        ' method.
        startPoint = control.PointToScreen(New Point(e.X, e.Y))
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As _
    System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        ' If the mouse is being dragged, undraw and redraw the rectangle
        ' as the mouse moves.
        If (isDrag) Then

            ' Hide the previous rectangle by calling the DrawReversibleFrame 
            ' method with the same parameters.
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, _
                FrameStyle.Dashed)

            ' Calculate the endpoint and dimensions for the new rectangle, 
            ' again using the PointToScreen method.
            Dim endPoint As Point = CType(sender, Control).PointToScreen(New Point(e.X, e.Y))
            Dim width As Integer = endPoint.X - startPoint.X
            Dim height As Integer = endPoint.Y - startPoint.Y
            theRectangle = New Rectangle(startPoint.X, startPoint.Y, _
                width, height)

            ' Draw the new rectangle by calling DrawReversibleFrame again.  
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, _
                 FrameStyle.Dashed)
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As _
    System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

        ' If the MouseUp event occurs, the user is not dragging.
        isDrag = False

        ' Draw the rectangle to be evaluated. Set a dashed frame style 
        ' using the FrameStyle enumeration.
        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, _
            FrameStyle.Dashed)

        ' Find out which controls intersect the rectangle and change their color.
        ' The method uses the RectangleToScreen method to convert the 
        ' Control's client coordinates to screen coordinates.
        Dim i As Integer
        Dim controlRectangle As Rectangle
        For i = 0 To Controls.Count - 1
            controlRectangle = Controls(i).RectangleToScreen _
                (Controls(i).ClientRectangle)
            If controlRectangle.IntersectsWith(theRectangle) Then
                Controls(i).BackColor = Color.BurlyWood
            End If
        Next

        ' Reset the rectangle.
        theRectangle = New Rectangle(0, 0, 0, 0)
    End Sub