   void showKeyword_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Display help using the provided keyword.
      Help::ShowHelp( this, helpfile, keyword->Text );
   }