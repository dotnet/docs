private:
   Void radioButton1_CheckedChanged( System::Object^ sender, System::EventArgs^ e )
   {
      // Change the check box position to be opposite its current position.
      if ( radioButton1->CheckAlign == ContentAlignment::MiddleLeft )
      {
         radioButton1->CheckAlign = ContentAlignment::MiddleRight;
      }
      else
      {
         radioButton1->CheckAlign = ContentAlignment::MiddleLeft;
      }
   }