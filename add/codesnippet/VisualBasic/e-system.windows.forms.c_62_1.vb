Private Sub currencyTextBox_TextChanged(sender As Object, _ 
  e As EventArgs) Handles currencyTextBox.TextChanged
   Try
      ' Convert the text to a Double and determine if it is a negative number.
      If Double.Parse(currencyTextBox.Text) < 0 Then
         ' If the number is negative, display it in Red.
         currencyTextBox.ForeColor = Color.Red
      Else
         ' If the number is not negative, display it in Black.
         currencyTextBox.ForeColor = Color.Black
      End If
   Catch
      ' If there is an error, display the text using the system colors.
      currencyTextBox.ForeColor = SystemColors.ControlText
   End Try
End Sub 