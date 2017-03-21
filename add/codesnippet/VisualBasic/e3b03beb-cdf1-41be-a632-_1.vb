    Private Sub ValidateUserEntry()

        ' Checks the value of the text.

        If ServerName.Text.Length = 0 Then

            ' Initializes variables to pass to the MessageBox.Show method.

            Dim Message As String = "You did not enter a server name. Cancel this operation?"
            Dim Caption As String = "Error Detected in Input"
            Dim Buttons As MessageBoxButtons = MessageBoxButtons.YesNo

            Dim Result As DialogResult

            'Displays the MessageBox

            Result = MessageBox.Show(Message, Caption, Buttons)

            ' Gets the result of the MessageBox display.

            If Result = System.Windows.Forms.DialogResult.Yes Then

                ' Closes the parent form.

                Me.Close()

            End If

        End If

    End Sub