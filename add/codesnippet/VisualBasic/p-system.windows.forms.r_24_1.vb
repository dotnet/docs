   Private Sub WriteIndentedTextToRichTextBox()
      ' Clear all text from the RichTextBox;
      RichTextBox1.Clear()
      ' Set the font for the text.
      RichTextBox1.Font = New Font("Lucinda Console", 12)
      ' Specify a 20 pixel right indent in all paragraphs.
      RichTextBox1.SelectionRightIndent = 20
      ' Set the text within the control.
      RichTextBox1.SelectedText = "All text is indented 20 pixels from the right edge of the RichTextBox."
      RichTextBox1.SelectedText = "You can use this property with the SelectionIndent property to provide right and left margins."
      RichTextBox1.SelectedText = "After this paragraph the indentation will end." + ControlChars.CrLf
      ' Remove all right indentation.
      RichTextBox1.SelectionRightIndent = 0
      RichTextBox1.SelectedText = "This paragraph has no right indentation. All text should flow as normal."
   End Sub