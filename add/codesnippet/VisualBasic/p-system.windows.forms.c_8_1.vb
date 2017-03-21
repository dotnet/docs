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