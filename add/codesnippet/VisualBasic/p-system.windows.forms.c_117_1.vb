   Private Sub myButton_Click(sender As Object, e As EventArgs)
      Dim myFontDialog As FontDialog
      myFontDialog = New FontDialog()
      
      If myFontDialog.ShowDialog() = DialogResult.OK Then
         ' Set the control's font.
         myDateTimePicker.Font = myFontDialog.Font
      End If
   End Sub