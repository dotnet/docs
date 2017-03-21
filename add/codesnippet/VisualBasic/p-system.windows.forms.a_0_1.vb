        Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles button1.Click

            If radioButton1.Checked Then
                Application.VisualStyleState = _
                    VisualStyleState.ClientAreaEnabled
            ElseIf radioButton2.Checked Then
                Application.VisualStyleState = _
                    VisualStyleState.NonClientAreaEnabled
            ElseIf radioButton3.Checked Then
                Application.VisualStyleState = _
                    VisualStyleState.ClientAndNonClientAreasEnabled
            ElseIf radioButton4.Checked Then
                Application.VisualStyleState = _
                    VisualStyleState.NoneEnabled
            End If

            ' Repaint the form and all child controls.
            Me.Invalidate(True)
        End Sub