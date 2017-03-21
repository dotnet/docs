   // Navigates WebBrowser1 to the next page in history.
   void ButtonForward_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->GoForward();
   }

   // Disables the Forward button at the end of navigation history.
   void WebBrowser1_CanGoForwardChanged( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->ButtonForward->Enabled = this->WebBrowser1->CanGoForward;
   }