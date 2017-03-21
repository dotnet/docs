   Private Sub ShowMyOwnedForm()
      ' Create an instance of the form to be owned.
      Dim ownedForm As New Form()
      ' Set the text of the form to identify it is an owned form.
      ownedForm.Text = "Owned Form"
      ' Add ownedForm to array of owned forms.
      Me.AddOwnedForm(ownedForm)

      ' Show the owned form.
      ownedForm.Show()
   End Sub