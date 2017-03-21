    ' This example demonstrates how to use the KeyUp event with the Help class to display
    ' pop-up style help to the user of the application. When the user presses F1, the Help
    ' class displays a pop-up window, similar to a ToolTip, near the control. This example assumes
    ' that a TextBox control, named textBox1, has been added to the form and its KeyUp
    ' event has been contected to this event handler method.
    Private Sub textBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textBox1.KeyUp
        ' Determine whether the key entered is the F1 key. Display help if it is.
        If e.KeyCode = Keys.F1 Then
            ' Display a pop-up help topic to assist the user.
            Help.ShowPopup(textBox1, "Enter your first name", New Point(textBox1.Right, Me.textBox1.Bottom))
        End If
    End Sub 'textBox1_KeyUp