// This button is a simple extension of the button class that overrides
// the ProcessMnemonic method.  If the mnemonic is correctly entered,  
// the message box will appear and the click event will be raised.  
// This method makes sure the control is selectable and the 
// mnemonic is correct before displaying the message box
// and triggering the click event.
public ref class MyMnemonicButton: public Button
{
protected:
   bool ProcessMnemonic( char inputChar )
   {
      if ( CanSelect && IsMnemonic( inputChar, this->Text ) )
      {
         MessageBox::Show( "You've raised the click event "
         "using the mnemonic." );
         this->PerformClick();
         return true;
      }

      return false;
   }

};

