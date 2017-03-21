        ' Draw the radio button in the current state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            RadioButtonRenderer.DrawRadioButton(e.Graphics, _
                Me.ClientRectangle.Location, TextRectangle, Me.Text, _
                Me.Font, clicked, state)
        End Sub

        ' Draw the radio button in the checked or unchecked state.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If Not clicked Then
                clicked = True
                Me.Text = "Clicked!"
                state = RadioButtonState.CheckedPressed
                Invalidate()
            Else
                clicked = False
                Me.Text = "Click here"
                state = RadioButtonState.UncheckedNormal
                Invalidate()
            End If

        End Sub