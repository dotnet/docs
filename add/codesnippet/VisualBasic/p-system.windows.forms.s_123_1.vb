        ' Draw the scroll bar in its normal state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ' Visual styles are not enabled.
            If Not ScrollBarRenderer.IsSupported Then
                Me.Parent.Text = "CustomScrollBar Disabled"
                Return
            End If

            Me.Parent.Text = "CustomScrollBar Enabled"

            ' Draw the scroll bar track.
            ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics, _
                Me.ClientRectangle, ScrollBarState.Normal)

            ' Draw the thumb and thumb grip in the current state.
            ScrollBarRenderer.DrawHorizontalThumb(e.Graphics, _
                thumbRectangle, thumbState)
            ScrollBarRenderer.DrawHorizontalThumbGrip(e.Graphics, _
                thumbRectangle, thumbState)

            ' Draw the scroll arrows in the current state.
            ScrollBarRenderer.DrawArrowButton(e.Graphics, _
                leftArrowRectangle, leftButtonState)
            ScrollBarRenderer.DrawArrowButton(e.Graphics, _
                rightArrowRectangle, rightButtonState)

            ' Draw a highlighted rectangle in the left side of the scroll 
            ' bar track if the user has clicked between the left arrow 
            ' and thumb.
            If leftBarClicked Then
                clickedBarRectangle.X = thumbLeftLimit
                clickedBarRectangle.Width = thumbRectangle.X - thumbLeftLimit
                ScrollBarRenderer.DrawLeftHorizontalTrack(e.Graphics, _
                    clickedBarRectangle, ScrollBarState.Pressed)

            ' Draw a highlighted rectangle in the right side of the scroll 
            ' bar track if the user has clicked between the right arrow 
            ' and thumb.
            ElseIf rightBarClicked Then
                clickedBarRectangle.X = thumbRectangle.X + _
                    thumbRectangle.Width
                clickedBarRectangle.Width = thumbRightLimitRight - _
                    clickedBarRectangle.X
                ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics, _
                    clickedBarRectangle, ScrollBarState.Pressed)
            End If
        End Sub