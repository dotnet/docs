        ' Draw the check box in the current state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            CheckBoxRenderer.DrawCheckBox(e.Graphics, _
                Me.ClientRectangle.Location, TextRectangle, Me.Text, _
                Me.Font, TextFormatFlags.HorizontalCenter, _
                clicked, state)
        End Sub

        ' Draw the check box in the checked or unchecked state, alternately.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If Not clicked Then
                With Me
                    .clicked = True
                    .Text = "Clicked!"
                    .state = CheckBoxState.CheckedPressed
                End With
                Invalidate()
            Else
                With Me
                    .clicked = False
                    .Text = "Click here"
                    .state = CheckBoxState.UncheckedNormal
                End With
                Invalidate()
            End If
        End Sub
