    Private Sub richTextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles richTextBox1.MouseDown
        ' Determine which mouse button is clicked.
        If e.Button = MouseButtons.Left Then
            ' Obtain the character at which the mouse cursor was clicked.
            Dim tempChar As Char = richTextBox1.GetCharFromPosition(New Point(e.X, e.Y))
            ' Determine whether the character is an empty space.
            If tempChar <> " " Then
                ' Display the character in a message box.
                MessageBox.Show(("The character at the specified position is " + tempChar + "."))
            End If
        End If
    End Sub