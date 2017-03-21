   // Navigates to the URL in the address text box when 
   // the ENTER key is pressed while the text box has focus.
   void TextBoxAddress_KeyDown( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      if ( e->KeyCode == System::Windows::Forms::Keys::Enter &&  !this->TextBoxAddress->Text->Equals( "" ) )
      {
         this->WebBrowser1->Navigate( this->TextBoxAddress->Text );
      }
   }

   // Navigates to the URL in the address text box when 
   // the Go button is clicked.
   void ButtonGo_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if (  !this->TextBoxAddress->Text->Equals( "" ) )
      {
         this->WebBrowser1->Navigate( this->TextBoxAddress->Text );
      }
   }

   // Updates the URL in TextBoxAddress upon navigation.
   void WebBrowser1_Navigated( Object^ /*sender*/, System::Windows::Forms::WebBrowserNavigatedEventArgs^ /*e*/ )
   {
      this->TextBoxAddress->Text = this->WebBrowser1->Url->ToString();
   }
