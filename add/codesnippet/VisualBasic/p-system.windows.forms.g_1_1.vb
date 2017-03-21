    ' Match application style and toggle visual styles off
    ' and on for the application.
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        GroupBoxRenderer.RenderMatchingApplicationState = True

        Application.VisualStyleState = _
            Application.VisualStyleState Xor _
            VisualStyleState.ClientAndNonClientAreasEnabled

        If Application.RenderWithVisualStyles Then
            Me.Text = "Visual Styles Enabled"
        Else
            Me.Text = "Visual Styles Disabled"
        End If

    End Sub