    Private Sub richTextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles richTextBox1.MouseDown
        ' Declare the string to search for in the control.
        Dim searchString As String = "brown"

        ' Determine whether the user clicks the left mouse button and whether it is a double click.
        If e.Clicks = 1 And e.Button = MouseButtons.Left Then
            ' Obtain the character index where the user clicks on the control.
            Dim positionToSearch As Integer = richTextBox1.GetCharIndexFromPosition(New Point(e.X, e.Y))
            ' Search for the search string text within the control from the point the user clicked.
            Dim textLocation As Integer = richTextBox1.Find(searchString, positionToSearch, RichTextBoxFinds.None)

            ' If the search string is found (value greater than -1), display the index the string was found at.
            If textLocation >= 0 Then
                MessageBox.Show(("The search string was found at character index " + textLocation.ToString() + "."))
                ' Display a message box alerting the user that the text was not found.
            Else
                MessageBox.Show("The search string was not found within the text of the control.")
            End If
        End If
    End Sub