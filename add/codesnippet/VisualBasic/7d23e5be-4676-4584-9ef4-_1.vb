        ' Draw the large or small button, depending on the current state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ' Draw the smaller pressed button image.
            If state = PushButtonState.Pressed Then
                ' Set the background color to the parent if visual styles  
                ' are disabled, because DrawParentBackground will only paint  
                ' over the control background if visual styles are enabled.
                If Application.RenderWithVisualStyles Then
                    Me.BackColor = Color.Azure
                Else
                    Me.BackColor = Me.Parent.BackColor
                End If

                ' If you comment out the call to DrawParentBackground,   
                ' the background of the control will still be visible 
                ' outside the pressed button, if visual styles are enabled.
                ButtonRenderer.DrawParentBackground(e.Graphics, _
                    Me.ClientRectangle, Me)
                ButtonRenderer.DrawButton(e.Graphics, ClickRectangle, _
                    Me.Text, Me.Font, True, state)

            ' Draw the bigger unpressed button image.
            Else
                ButtonRenderer.DrawButton(e.Graphics, Me.ClientRectangle, _
                    Me.Text, Me.Font, False, state)
            End If
        End Sub

        ' Draw the smaller pressed button image.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            With Me
                .Text = "Clicked!"
                .state = PushButtonState.Pressed
            End With
            Invalidate()
        End Sub

        ' Draw the button in the hot state. 
        Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
            MyBase.OnMouseEnter(e)
            With Me
                .Text = "Click here"
                .state = PushButtonState.Hot
            End With
            Invalidate()
        End Sub

        ' Draw the button in the unpressed state.
        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MyBase.OnMouseLeave(e)
            With Me
                .Text = "Click here"
                .state = PushButtonState.Normal
            End With
            Invalidate()
        End Sub