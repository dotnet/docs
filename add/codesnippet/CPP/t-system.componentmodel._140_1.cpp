      try
      {
         //Attempting to pass an invalid enum value (MessageBoxButtons) to the Show method
         MessageBoxButtons myButton = (MessageBoxButtons)123; // to fix use System::Windows::Forms::DialogResult::OK;

         MessageBox::Show( this,  "This is a message",  "This is the Caption", myButton );
      }
      catch ( InvalidEnumArgumentException^ invE ) 
      {
         Console::WriteLine( invE->Message );
         Console::WriteLine( invE->ParamName );
         Console::WriteLine( invE->StackTrace );
         Console::WriteLine( invE->Source );
      }