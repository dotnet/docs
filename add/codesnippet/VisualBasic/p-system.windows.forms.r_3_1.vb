    Private Sub ModifySelectedText()
        ' Determine if text is selected in the control.
        If (richTextBox1.SelectionLength > 0) Then
            ' Set the color of the selected text in the control.
            richTextBox1.SelectionColor = Color.Red
            ' Set the font of the selected text to bold and underlined.
            richTextBox1.SelectionFont = New Font("Arial", 10, FontStyle.Bold Or FontStyle.Underline)
            ' Protect the selected text from modification.
            richTextBox1.SelectionProtected = True
        End If
    End Sub