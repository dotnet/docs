   Private Sub ToggleBold()
      If richTextBox1.SelectionFont IsNot Nothing Then
         Dim currentFont As System.Drawing.Font = richTextBox1.SelectionFont
         Dim newFontStyle As System.Drawing.FontStyle

         If richTextBox1.SelectionFont.Bold = True Then
            newFontStyle = FontStyle.Regular
         Else
            newFontStyle = FontStyle.Bold
         End If

         richTextBox1.SelectionFont = New Font( _
            currentFont.FontFamily, _
            currentFont.Size, _
            newFontStyle _
         )
      End If
   End sub