   // Navigates WebBrowser1 to the previous page in the history.
   void backButton_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->GoBack();
   }

   // Disables the Back button at the beginning of the navigation history.
   void WebBrowser1_CanGoBackChanged( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->backButton->Enabled = this->WebBrowser1->CanGoBack;
   }