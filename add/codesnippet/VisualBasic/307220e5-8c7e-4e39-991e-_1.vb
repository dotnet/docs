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