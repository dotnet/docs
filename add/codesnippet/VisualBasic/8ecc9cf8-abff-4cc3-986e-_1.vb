        ' Use DrawText with the current TextFormatFlags.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If TextBoxRenderer.IsSupported Then
                TextBoxRenderer.DrawTextBox(e.Graphics, textBorder, Me.Text, _
                    Me.Font, textRectangle, textFlags, TextBoxState.Normal)
                Me.Parent.Text = "CustomTextBox Enabled"
            Else
                Me.Parent.Text = "CustomTextBox Disabled"
            End If
        End Sub