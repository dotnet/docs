private:
   void validateUserEntry5()
   {
      // Checks the value of the text.
      if ( serverName->Text->Length == 0 )
      {
         // Initializes the variables to pass to the MessageBox::Show method.
         String^ message = "You did not enter a server name. Cancel this operation?";
         String^ caption = "No Server Name Specified";
         MessageBoxButtons buttons = MessageBoxButtons::YesNo;
         System::Windows::Forms::DialogResult result;

         // Displays the MessageBox.
         result = MessageBox::Show( this, message, caption, buttons );
         if ( result == ::DialogResult::Yes )
         {
            // Closes the parent form.
            this->Close();
         }
      }
   }