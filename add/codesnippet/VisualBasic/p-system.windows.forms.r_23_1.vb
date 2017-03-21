   Private Sub WriteIndentedTextToRichTextBox()
      ' Clear all text from the RichTextBox;
      RichTextBox1.Clear()
      ' Set the font for the text.
      RichTextBox1.Font = New Font("Lucinda Console", 12)
      ' Specify a 20 pixel indent in all paragraphs.
      RichTextBox1.SelectionIndent = 20
      ' Set the text within the control.
      RichTextBox1.SelectedText = "All text is indented 20 pixels from the left edge of the RichTextBox."
      RichTextBox1.SelectedText = "You can use this property to provide proper indentation such as when writing a letter."
      RichTextBox1.SelectedText = "After this paragraph the indent is returned to normal spacing." + ControlChars.Crlf
      RichTextBox1.SelectionIndent = 0
      RichTextBox1.SelectedText = "No indenation is applied to this paragraph. All text in the paragraph flows from each control edge."
   End Sub