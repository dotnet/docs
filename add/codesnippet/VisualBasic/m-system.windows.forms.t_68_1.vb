   Private Sub AppendTextBox1Text()
      ' Determine if text is selected in textBox1.
      If textBox1.SelectionLength = 0 Then
         ' No selection made, return.
         Return
      End If
      ' Determine if the text being appended to textBox2 exceeds the MaxLength property.
      If textBox1.SelectedText.Length + textBox2.TextLength > textBox2.MaxLength Then
         MessageBox.Show("The text to paste in is larger than the maximum number of characters allowed")
         ' Append the text from textBox1 into textBox2.
      Else
         textBox2.AppendText(textBox1.SelectedText)
      End If
   End Sub