    Private Sub ValidateUserEntry5()

        ' Checks the value of the text.

        If ServerName.Text.Length = 0 Then

            ' Initializes variables to pass to the MessageBox.Show method.

            Dim Message As String = "You did not enter a server name. Cancel this operation?"
            Dim Caption As String = "No Server Name Specified"
            Dim Buttons As Integer = MessageBoxButtons.YesNo

            Dim Result As DialogResult

            'Displays a MessageBox using the Question icon and specifying the No button as the default.

            Result = MessageBox.Show(Me, Message, Caption, MessageBoxButtons.YesNo)

            ' Gets the result of the MessageBox display.

            If Result = System.Windows.Forms.DialogResult.Yes Then

                ' Closes the parent form.

                Me.Close()

            End If

        End If

    End Sub