      Controls.Add(myForm);
      myForm.Controls.Add(myLabel1);
      myForm.Controls.Add(myTextBox);
      myForm.Controls.Add(myButton);
      this.Validators.Add(myRequiredFieldValidator);
      myForm.Controls.Add(myLabel);


      // Remove the RequiredFieldValidator.
      if(Validators.Contains(myRequiredFieldValidator))
      {
         this.Validators.Remove(myRequiredFieldValidator);
         Response.Write("RequiredFieldValidator is removed from ValidatorCollection<br>");
         Response.Write("ValidatorCollection count after removing the Validator: "+Validators.Count+"<br>");
      }
      else
      {
         Response.Write("ValidatorCollection does not contain RequiredFieldValidator");
      }