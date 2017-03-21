    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False
   
   
    ' Handle the KeyDown event to determine the type of character entered into the control.
    Private Sub textBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) _
         Handles textBox1.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False
      
        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
        'If shift key was pressed, it's not a number.
        If Control.ModifierKeys = Keys.Shift Then
            nonNumberEntered = true
        End If
    End Sub 'textBox1_KeyDown
   
   
    ' This event occurs after the KeyDown event and can be used 
    ' to prevent characters from entering the control.
    Private Sub textBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) _
        Handles textBox1.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        End If
    End Sub 'textBox1_KeyPress