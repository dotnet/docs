   // Navigates WebBrowser1 to the search page of the current user.
   void ButtonSearch_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->GoSearch();
   }