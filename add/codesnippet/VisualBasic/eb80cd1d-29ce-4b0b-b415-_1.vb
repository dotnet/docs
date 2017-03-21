        ' Draw the combo box in the current state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If Not ComboBoxRenderer.IsSupported Then
                Me.Parent.Text = "Visual Styles	Disabled"
                Return
            End If

            Me.Parent.Text = "CustomComboBox Enabled"

            ' Always draw the main text box and drop down arrow in their 
            ' current states.
            ComboBoxRenderer.DrawTextBox(e.Graphics, topTextBoxRectangle, _
                Me.Text, Me.Font, textBoxState)
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, arrowRectangle, _
                arrowState)

            ' Only draw the bottom text box if the arrow has been clicked.
            If isActivated Then
                ComboBoxRenderer.DrawTextBox(e.Graphics, _
                    bottomTextBoxRectangle, bottomText, Me.Font, textBoxState)
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            ' Check whether the user clicked the arrow.
            If arrowRectangle.Contains(e.Location) And _
                ComboBoxRenderer.IsSupported Then

                ' Draw the arrow in the pressed state.
                arrowState = ComboBoxState.Pressed

                ' The user has activated the combo box.
                If Not isActivated Then
                    Me.Text = "Clicked!"
                    textBoxState = ComboBoxState.Pressed
                    isActivated = True

                ' The user has deactivated the combo box.
                Else
                    Me.Text = "Click here"
                    textBoxState = ComboBoxState.Normal
                    isActivated = False
                End If

                ' Redraw the control.
                Invalidate()
            End If
        End Sub