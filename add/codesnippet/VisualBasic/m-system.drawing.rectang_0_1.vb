    Dim rectangle1 As New Rectangle(70, 70, 100, 150)

    Private Sub DrawFirstRectangle()
        ControlPaint.DrawReversibleFrame(rectangle1, _
            SystemColors.Highlight, FrameStyle.Thick)
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button1.Click

        ' Get the bounds of the screen.
        Dim screenRectangle As Rectangle = Screen.PrimaryScreen.Bounds

        ' Check to see if the rectangle is within the bounds of the screen.
        If (screenRectangle.Contains(rectangle1)) Then

            ' If so, erase the previous rectangle.
            ControlPaint.DrawReversibleFrame(rectangle1, _
                SystemColors.Highlight, FrameStyle.Thick)

            ' Call the Offset method to move the rectangle.
            rectangle1.Offset(20, 20)

            ' Draw the new, offset rectangle.
            ControlPaint.DrawReversibleFrame(rectangle1, _
                SystemColors.Highlight, FrameStyle.Thick)
        End If
    End Sub