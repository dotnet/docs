   private:
      void currencyTextBox_TextChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         try
         {
            // Convert the text to a Double and determine if it is a negative number.
            if ( Double::Parse( currencyTextBox->Text ) < 0 )
            {
               // If the number is negative, display it in Red.
               currencyTextBox->ForeColor = Color::Red;
            }
            else
            {
               // If the number is not negative, display it in Black.
               currencyTextBox->ForeColor = Color::Black;
            }
         }
         catch ( Exception^ ) 
         {
            // If there is an error, display the text using the system colors.
            currencyTextBox->ForeColor = SystemColors::ControlText;
         }
      }