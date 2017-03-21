   // Boolean flag used to determine when a character other than a number is entered.
private:
   bool nonNumberEntered;

   // Handle the KeyDown event to determine the type of character entered into the control.
   void textBox1_KeyDown( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      // Initialize the flag to false.
      nonNumberEntered = false;

      // Determine whether the keystroke is a number from the top of the keyboard.
      if ( e->KeyCode < Keys::D0 || e->KeyCode > Keys::D9 )
      {
         // Determine whether the keystroke is a number from the keypad.
         if ( e->KeyCode < Keys::NumPad0 || e->KeyCode > Keys::NumPad9 )
         {
            // Determine whether the keystroke is a backspace.
            if ( e->KeyCode != Keys::Back )
            {
               // A non-numerical keystroke was pressed.
               // Set the flag to true and evaluate in KeyPress event.
               nonNumberEntered = true;
            }
         }
      }
      //If shift key was pressed, it's not a number.
      if (Control::ModifierKeys == Keys::Shift) {
         nonNumberEntered = true;
      }
   }

   // This event occurs after the KeyDown event and can be used to prevent
   // characters from entering the control.
   void textBox1_KeyPress( Object^ /*sender*/, System::Windows::Forms::KeyPressEventArgs^ e )
   {
      // Check for the flag being set in the KeyDown event.
      if ( nonNumberEntered == true )
      {         // Stop the character from being entered into the control since it is non-numerical.
         e->Handled = true;
      }
   }