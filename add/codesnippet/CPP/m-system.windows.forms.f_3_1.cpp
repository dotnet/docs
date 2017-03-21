private:
   void ShowMyOwnedForm()
   {
      // Create an instance of the form to be owned.
      Form^ ownedForm = gcnew Form;

      // Set the text of the form to identify it is an owned form.
      ownedForm->Text = "Owned Form";

      // Add ownedForm to array of owned forms.
      this->AddOwnedForm( ownedForm );

      // Show the owned form.
      ownedForm->Show();
   }