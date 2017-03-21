Protected Overrides Sub OnTextChanged(e As System.EventArgs)
   Try
      ' Convert the text to a Double and determine
      ' if it is a negative number.
      If Double.Parse(Me.Text) < 0 Then
         ' If the number is negative, display it in Red.
         Me.ForeColor = Color.Red
      Else
         ' If the number is not negative, display it in Black.
         Me.ForeColor = Color.Black
      End If
   Catch
      ' If there is an error, display the
      ' text using the system colors.
      Me.ForeColor = SystemColors.ControlText
   End Try

   MyBase.OnTextChanged(e)
End Sub