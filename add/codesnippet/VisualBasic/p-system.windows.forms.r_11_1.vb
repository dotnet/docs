   Private Sub WriteOffsetTextToRichTextBox()
      ' Clear all text from the RichTextBox.
      RichTextBox1.Clear()
      ' Set the font for the text.
      RichTextBox1.SelectionFont = New Font("Lucinda Console", 12)
      ' Set the foreground color of the text.
      RichTextBox1.SelectionColor = Color.Purple
      ' Set the baseline text.
      RichTextBox1.SelectedText = "10"
      ' Set the CharOffset to display superscript text.
      RichTextBox1.SelectionCharOffset = 10
      ' Set the superscripted text.	
      RichTextBox1.SelectedText = "2"
      ' Reset the CharOffset to display text at the baseline.
      RichTextBox1.SelectionCharOffset = 0
      RichTextBox1.SelectedText = ControlChars.CrLf + ControlChars.CrLf
      ' Change the forecolor of the next text selection.
      RichTextBox1.SelectionColor = Color.Blue
      ' Set the baseline text.
      RichTextBox1.SelectedText = "777"
      ' Set the CharOffset to display subscript text.
      RichTextBox1.SelectionCharOffset = -10
      ' Set the subscripted text.  
      RichTextBox1.SelectedText = "3"
      ' Reset the CharOffset to display text at the baseline.
      RichTextBox1.SelectionCharOffset = 0
   End Sub