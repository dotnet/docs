    Public Sub New()
        MyBase.New()

        InitializeComponent()
        'Set button2 to be non-validating.
        Me.button2.CausesValidation = False
    End Sub

   Private Function ValidEmailAddress(ByVal emailAddress As String, ByRef errorMessage As String) As Boolean
      ' Confirm there is text in the control.
      If textBox1.Text.Length = 0 Then
         errorMessage = "E-mail address is required."
         Return False

      End If

      ' Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
      If emailAddress.IndexOf("@") > -1 Then
         If (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@")) Then
            errorMessage = ""
            Return True
         End If
      End If

      errorMessage = "E-mail address must be valid e-mail address format." + ControlChars.Cr + _
        "For example 'someone@example.com' "
      Return False
End Function

   Private Sub textBox1_Validating(ByVal sender As Object, _
   ByVal e As System.ComponentModel.CancelEventArgs) Handles textBox1.Validating

      Dim errorMsg As String
      If Not ValidEmailAddress(textBox1.Text, errorMsg) Then
         ' Cancel the event and select the text to be corrected by the user.
         e.Cancel = True
         textBox1.Select(0, textBox1.Text.Length)

         ' Set the ErrorProvider error with the text to display. 
         Me.errorProvider1.SetError(textBox1, errorMsg)
      End If
   End Sub


   Private Sub textBox1_Validated(ByVal sender As Object, _
   ByVal e As System.EventArgs) Handles textBox1.Validated
      ' If all conditions have been met, clear the error provider of errors.
      errorProvider1.SetError(textBox1, "")
   End Sub