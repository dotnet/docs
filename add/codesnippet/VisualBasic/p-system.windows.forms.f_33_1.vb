   Private Sub AddMyOwnedForm()
      ' Create form to be owned.
      Dim ownedForm As New Form()
      ' Set the text of the owned form.
      ownedForm.Text = "Owned Form " + Me.OwnedForms.Length.ToString()
      ' Add the form to the array of owned forms.
      Me.AddOwnedForm(ownedForm)
      ' Show the owned form.
      ownedForm.Show()
   End Sub


   Private Sub ChangeOwnedFormText()
      Dim x As Integer
      ' Loop through all owned forms and change their text.
      For x = 0 To (Me.OwnedForms.Length) - 1
         Me.OwnedForms(x).Text = "My Owned Form " + x.ToString()
      Next x
   End Sub