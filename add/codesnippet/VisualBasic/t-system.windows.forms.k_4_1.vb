    Private Sub textBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textBox1.KeyDown
        ' Determine whether the key entered is the F1 key. If it is, display Help.
        If e.KeyCode = Keys.F1 AndAlso (e.Alt OrElse e.Control OrElse e.Shift) Then
            ' Display a pop-up Help topic to assist the user.
            Help.ShowPopup(textBox1, "Enter your name.", New Point(textBox1.Bottom, textBox1.Right))
        ElseIf e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            ' Display a pop-up Help topic to provide additional assistance to the user.
            Help.ShowPopup(textBox1, "Enter your first name followed by your last name. Middle name is optional.", _
                 New Point(textBox1.Top, Me.textBox1.Left))
        End If
    End Sub 'textBox1_KeyDown