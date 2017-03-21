      Controls.Add(myForm)
      myForm.Controls.Add(myLabel1)
      myForm.Controls.Add(myTextBox)
      myForm.Controls.Add(myButton)
      Me.Validators.Add(myRequiredFieldValidator)
      myForm.Controls.Add(myLabel)

     ' Remove the RequiredFieldValidator.
      If Validators.Contains(myRequiredFieldValidator) Then
         Me.Validators.Remove(myRequiredFieldValidator)
         Response.Write("RequiredFieldValidator is removed from ValidatorCollection<br>")
         Response.Write("ValidatorCollection count after removing the Validator: " + Validators.Count.ToString() + "<br>")
      Else
         Response.Write("ValidatorCollection does not contain RequiredFieldValidator")
      End If