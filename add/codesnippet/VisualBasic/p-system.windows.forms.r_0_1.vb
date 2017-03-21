   Private Sub ProtectMySelectedText()
      ' Determine if the selected text in the control contains the word "RichTextBox".
      If richTextBox1.SelectedText <> "RichTextBox" Then
         ' Search for the word RichTextBox in the control.
         If richTextBox1.Find("RichTextBox", RichTextBoxFinds.WholeWord) = -1 Then
            'Alert the user that the word was not foun and return.
            MessageBox.Show("The text ""RichTextBox"" was not found!")
            Return
         End If
      End If
      ' Protect the selected text in the control from being altered.
      richTextBox1.SelectionProtected = True
   End Sub