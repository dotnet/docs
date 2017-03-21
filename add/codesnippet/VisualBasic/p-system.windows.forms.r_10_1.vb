   Private Sub WriteIndentedTextToRichTextBox()
      ' Clear all text from the RichTextBox;
      RichTextBox1.Clear()
      ' Set the font for the text.
      RichTextBox1.Font = New Font("Lucinda Console", 12)
      ' Specify a 20 pixel hanging indent in all paragraphs.
      RichTextBox1.SelectionHangingIndent = 20
      ' Set the text within the control.
      RichTextBox1.SelectedText = "VBThis text contains a hanging indent. The first sentence of the paragraph is spaced normally."
      RichTextBox1.SelectedText = "All subsequent lines of text are indented based on the value of SelectionHangingIndent."
      RichTextBox1.SelectedText = "After this paragraph the indent is returned to normal spacing." + ControlChars.CrLf
      RichTextBox1.SelectedText = "Since this is a new paragraph the indent is also applied to this paragraph."
      RichTextBox1.SelectedText = "All subsequent lines of text are indented based on the value of SelectionHangingIndent."
   End Sub