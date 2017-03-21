private:
   void AddMyOwnedForm()
   {
      // Create form to be owned.
      Form^ ownedForm = gcnew Form;

      // Set the text of the owned form.
      ownedForm->Text = String::Format( "Owned Form {0}", this->OwnedForms->Length );

      // Add the form to the array of owned forms.
      this->AddOwnedForm( ownedForm );

      // Show the owned form.
      ownedForm->Show();
   }

   void ChangeOwnedFormText()
   {
      // Loop through all owned forms and change their text.
      for ( int x = 0; x < this->OwnedForms->Length; x++ )
      {
         this->OwnedForms[ x ]->Text = String::Format( "My Owned Form {0}", x );
      }
   }